using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIChooseLandToBuild : MonoBehaviour
{

    public static UIChooseLandToBuild instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public void SetUpUIToChoose()
    {
        foreach (ProductionData data in ProductionDatabase.instance.productionData)
        {
            data.productionBuildIcon.gameObject.SetActive(true);
            Debug.Log("pp");
            if (data.production.OnActivated)
                data.productionBuildIcon.gameObject.SetActive(false);
        }
    }
}
