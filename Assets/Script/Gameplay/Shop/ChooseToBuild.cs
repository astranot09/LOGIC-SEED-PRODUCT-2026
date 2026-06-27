using UnityEngine;

public class ChooseToBuild : MonoBehaviour
{
    [SerializeField] private ProductionLogicScript productionLogicScript;

    public void BuildGame()
    {
        productionLogicScript.SetUp(ShopManager.instance.ProductionCurr);
        UIChooseLandToBuild.instance.SetUpUIToChoose();
    }

}
