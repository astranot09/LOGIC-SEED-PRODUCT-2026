using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusProductionScript : MonoBehaviour
{

    public static StatusProductionScript instance;

    [Header("UI")]
    [SerializeField] private Image productionIcon;
    [SerializeField] private Image statusLight;
    [SerializeField] private TMP_Text productionName;

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

        if (production.ProductionData.sprite != null)
            productionIcon.sprite = production.ProductionData.sprite;

        if (production.ProductionData.productionName != null)
            productionName.text = production.ProductionData.name;


        UpdateStatusUI();

    }

    public void UpdateStatusUI()
    {
        if(production == null) return;
        if (production.OnActivated)
        {
            statusLight.color = Color.green;
            productionIcon.sprite = production.ProductionData.sprite;
        }
        else
        {
            statusLight.color = Color.red;
            productionIcon.sprite = production.ProductionData.sprite;
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
