using UnityEngine;
using UnityEngine.UI;

public class StatusProductionScript : MonoBehaviour
{

    public static StatusProductionScript instance;

    [Header("UI")]
    [SerializeField] private Image productIcon;
    [SerializeField] private Image statusLight;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private ProductionLogicScript production;
    [SerializeField] private GameObject statusProductionPanel;

    public void OpenStatusProduction(ProductionLogicScript script)
    {
        statusProductionPanel.SetActive(true);
        production = script;
        if(productIcon.sprite != null)
            productIcon.sprite = production.ProductionData.sprite;
        UpdateStatusUI();
    }

    public void UpdateStatusUI()
    {
        if (production.OnActivated)
        {
            // PERBAIKAN: Gunakan .color untuk mengubah warna, bukan .sprite
            statusLight.color = Color.green;
        }
        else
        {
            statusLight.color = Color.red;
        }
    }


    public void ActivatedDeactivatedProduction()
    {
        if(production.ProductionData == null) return;
        if (production.OnActivated)
        {
            production.DeactivatedProduction();
        }
        else
        {
            production.ActivatedProduction();
        }
        UpdateStatusUI();
    }

    public void CloseStatusProduction()
    {
        statusProductionPanel.SetActive(false);
    }
}
