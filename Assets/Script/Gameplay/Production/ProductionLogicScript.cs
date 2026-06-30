using Unity.VisualScripting;
using UnityEngine;

public class ProductionLogicScript : MonoBehaviour
{
    [Header("Production Data")]
    [SerializeField] private ProductionSO productionData;
    public ProductionSO ProductionData => productionData;

    [SerializeField] private float smokeWaste;
    [SerializeField] private float productionWaste;
    [SerializeField] private float profit;
    [SerializeField] private float currTimer;
    [SerializeField] private float maxTimer;


    [SerializeField] private bool onActivated;
    public bool OnActivated => onActivated;


    private SpriteRenderer spriteRenderer;

    [Header("Reference")]
    [SerializeField] private PlayerProfitScript profitScript;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (OnActivated)
        {
            //smokeWaste
            if(currTimer > 0)
            {
                currTimer -= Time.deltaTime;
            }
            else
            {
                SuccessProduction();
            }
        }
    }

    public void ActivatedProduction()
    {
        onActivated = true;
        currTimer = 5f;
    }

    public void DeactivatedProduction()
    {
        onActivated = false;
    }
    public void SuccessProduction()
    {
        currTimer = 5f;
        profitScript.AddProfit(CardManager.instance.FinalProfitCalculation(profit));
        //productionWaste
    }

    public void SetUp(ProductionSO productionSO)
    {
        this.productionData = productionSO;
        smokeWaste = productionData.smokeWaste;
        productionWaste = productionData.productionWaste;
        profit = productionData.profit;
        maxTimer = productionData.duration;
        spriteRenderer.sprite = productionData.sprite;
        currTimer = maxTimer;

        ActivatedProduction();
        StatusProductionScript.instance.UpdateStatusUI();
    }

    private void OnMouseDown()
    {
        if(productionData == null) return;

        StatusProductionScript.instance.OpenStatusProduction(this);
    }
}
