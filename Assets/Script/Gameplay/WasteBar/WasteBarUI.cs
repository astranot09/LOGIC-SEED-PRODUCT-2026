using UnityEngine;
using UnityEngine.UI;

public class WasteBarUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image barFilled;

    private void Start()
    {
        if (WasteManager.Instance != null)
        {
            WasteManager.Instance.OnWasteChanged += UpdateWasteBar;
        }

        UpdateWasteBar();
    }

    private void OnDestroy()
    {
        if (WasteManager.Instance != null)
        {
            WasteManager.Instance.OnWasteChanged -= UpdateWasteBar;
        }
    }

    public void UpdateWasteBar()
    {
        if (WasteManager.Instance == null)
            return;

        float currentWaste = WasteManager.Instance.CurrentWaste;
        float maxWaste = WasteManager.Instance.MaxWaste;

        barFilled.fillAmount = currentWaste / maxWaste;
    }
}