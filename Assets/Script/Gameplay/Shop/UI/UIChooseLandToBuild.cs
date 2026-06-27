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

    private void Start()
    {
        SetUpUIToChoose();
    }

    public void SetUpUIToChoose()
    {
        foreach (ProductionData data in ProductionDatabase.instance.productionData)
        {
            Debug.Log("pp");
            if (data.production.OnActivated)
                data.productionBuildIcon.gameObject.SetActive(false);
        }
    }
}
