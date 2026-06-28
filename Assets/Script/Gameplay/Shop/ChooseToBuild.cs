using UnityEngine;

public class ChooseToBuild : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private ProductionLogicScript productionLogicScript;
    [SerializeField] private PlayerProfitScript playerProfit;
    public void BuildProduction()
    {
        if(productionLogicScript.OnActivated) 
            return;

        productionLogicScript.SetUp(ShopManager.instance.ProductionCurr);
        UIChooseLandToBuild.instance.SetUpUIToChoose();
        playerProfit.RemoveProfit(productionLogicScript.ProductionData.productionPrice);
        ShopManager.instance.PlayerCanBuild();
    }

}
