using UnityEngine;

public class ProductionLogicScript : MonoBehaviour
{
    //Ambil Production SO

    [SerializeField] private float smokeWaste;
    [SerializeField] private float productionWaste;
    [SerializeField] private float profit;
    [SerializeField] private float currTimer;
    [SerializeField] private float maxTimer;


    [SerializeField] private bool OnActivated;

    [Header("Reference")]
    [SerializeField] private PlayerProfitScript profitScript;


    private void Start()
    {
        SetUp();
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
        OnActivated = true;
        currTimer = 5f;
    }

    public void DeactivatedProduction()
    {
        OnActivated = false;
    }
    public void SuccessProduction()
    {
        currTimer = 5f;
        profitScript.AddProfit(CardManager.instance.FinalProfitCalculation(profit));
        //productionWaste
    }

    public void SetUp()
    {
        smokeWaste = 1f;
        productionWaste = 1f;
        profit = 1f;
        maxTimer = 5f;
        currTimer = maxTimer;
        ActivatedProduction();
    }

}
