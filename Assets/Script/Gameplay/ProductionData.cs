using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ProductionData
{
    public ProductionLogicScript production;
    public Image productionBuildIcon;
}

public class ProductionDatabase : MonoBehaviour
{

    public static ProductionDatabase instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public List<ProductionData> productionData;

}
