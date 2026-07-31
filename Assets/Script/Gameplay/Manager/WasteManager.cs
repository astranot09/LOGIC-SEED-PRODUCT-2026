using System;
using System.Collections;
using UnityEngine;

public class WasteManager : MonoBehaviour
{
    public static WasteManager Instance;

    [Header("Waste")]
    [SerializeField] private int currentWaste = 0;
    [SerializeField] private int maxWaste = 1000;

    [SerializeField] private float countdownRemoveWaste = 2f;
    [SerializeField] private int removeWasteValue = 1;
    private Coroutine removeWasteCoroutine;

    public int CurrentWaste => currentWaste;
    public int MaxWaste => maxWaste;

    public event Action OnWasteChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartRemoveWasteRoutine();
    }

    public void AddWaste(int amount)
    {
        int x = CardManager.instance.FinalPolutionCalculation(amount);
        currentWaste += x;
        //currentWaste = Mathf.Clamp(currentWaste, 0, maxWaste);

        OnWasteChanged?.Invoke();

        Debug.Log($"Waste: {currentWaste}/{maxWaste}");

        if(currentWaste > maxWaste)
        {
            LoseScript.instance.PlayerLose();
        }
    }

    public void RemoveWaste(int amount)
    {
        currentWaste -= amount;
        currentWaste = Mathf.Clamp(currentWaste, 0, maxWaste);

        OnWasteChanged?.Invoke();

        Debug.Log($"Waste: {currentWaste}/{maxWaste}");
    }

    private void StartRemoveWasteRoutine()
    {
        if (removeWasteCoroutine == null)
        {
            removeWasteCoroutine = StartCoroutine(RemoveWasteLoop());
        }
    }
    private IEnumerator RemoveWasteLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(countdownRemoveWaste);

            if (currentWaste > 0 && currentWaste <= maxWaste)
            {
                RemoveWaste(removeWasteValue);
            }
        }
    }
}