using System;
using UnityEngine;

public class WasteManager : MonoBehaviour
{
    public static WasteManager Instance;

    [Header("Waste")]
    [SerializeField] private int currentWaste = 0;
    [SerializeField] private int maxWaste = 1000;

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

    public void AddWaste(int amount)
    {
        currentWaste += amount;
        currentWaste = Mathf.Clamp(currentWaste, 0, maxWaste);

        OnWasteChanged?.Invoke();

        Debug.Log($"Waste: {currentWaste}/{maxWaste}");
    }

    public void RemoveWaste(int amount)
    {
        currentWaste -= amount;
        currentWaste = Mathf.Clamp(currentWaste, 0, maxWaste);

        OnWasteChanged?.Invoke();

        Debug.Log($"Waste: {currentWaste}/{maxWaste}");
    }
}