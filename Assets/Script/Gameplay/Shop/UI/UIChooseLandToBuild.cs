using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIChooseLandToBuild : MonoBehaviour
{
    public void SetUpUIToChoose()
    {
        foreach(ProductionData data in ProductionDatabase.instance.productionData)
        {
            data.productionBuildIcon.gameObject.SetActive(false);
        }
    }
}
