using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ProductionLogicScript : DropSlot
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

    private Coroutine smokeCoroutine;

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

            if (currTimer > 0)
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
        currTimer = maxTimer;
        if (smokeCoroutine == null)
        {
            smokeCoroutine = StartCoroutine(SmokeWasteLoop());
        }
    }

    public void DeactivatedProduction()
    {
        onActivated = false;

        if (smokeCoroutine != null)
        {
            StopCoroutine(smokeCoroutine);
            smokeCoroutine = null;
        }
    }
    public void SuccessProduction()
    {
        currTimer = maxTimer;
        transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 1, 0.5f);
        profitScript.AddProfit(
            CardManager.instance.FinalProfitCalculation(profit)
        );

        WasteManager.Instance.AddWaste(
            Mathf.RoundToInt(productionWaste)
        );
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

    public override void SetItem(ProductionSO newProductionSO)
    {
        if (!OnActivated && newProductionSO != productionData)
        {
            PlayerProfitScript.instance.RemoveProfit(newProductionSO.productionPrice);
            base.SetItem(newProductionSO);
            SetUp(newProductionSO);
        }
        else
        {
            Debug.Log("Penuh Atau Mesinnya Sama");
        }
    }


    private IEnumerator SmokeWasteLoop()
    {
        while (onActivated)
        {
            yield return new WaitForSeconds(1f);

            if (WasteManager.Instance != null)
            {
                WasteManager.Instance.AddWaste(Mathf.RoundToInt(smokeWaste));
            }
        }
        smokeCoroutine = null;
    }

    private void OnMouseDown()
    {
        if(productionData == null) return;

        StatusProductionScript.instance.OpenStatusProduction(this);
    }
}
