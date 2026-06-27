using UnityEngine;

public class ChooseToBuild : MonoBehaviour
{
    [SerializeField] private ProductionLogicScript productionLogicScript;

    public void BuildProduction()
    {
        if(productionLogicScript.OnActivated) 
            return;

        productionLogicScript.SetUp(ShopManager.instance.ProductionCurr);
        UIChooseLandToBuild.instance.SetUpUIToChoose();
    }

}
