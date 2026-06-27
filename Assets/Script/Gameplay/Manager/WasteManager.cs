using UnityEngine;

public class WasteManager : MonoBehaviour
{
    public static WasteManager Instance;

    [Header("Waste")]
    public int currentWaste = 0;
    public int maxWaste = 1000;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentWaste = 0;
    }

    public void AddWaste(int wasteAdded)
    {
        currentWaste += wasteAdded;

        if (currentWaste < 0)
        {
            currentWaste = 0;
        }

        if (currentWaste > maxWaste)
        {
            Debug.Log("Waste exceeded!");

            //Go to lose scene
        }
    }
    public int ViewWaste()
    {
        return currentWaste;
    }
}