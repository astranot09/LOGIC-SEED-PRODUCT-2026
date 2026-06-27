using UnityEngine;

[CreateAssetMenu(fileName = "New Production",
                 menuName = "Factory/Production")]
public class ProductionSO : ScriptableObject
{
    public string productionName;
    public string description;
    public Sprite sprite;

    public float smokeWaste;
    public float productionWaste;

    public float profit;

    public float duration;

    public int pollutionRate;
    public int profitRate;
}