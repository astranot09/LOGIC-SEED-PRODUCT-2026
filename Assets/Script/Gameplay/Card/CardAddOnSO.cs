using UnityEngine;


[System.Serializable]
public enum AddOnType
{
    percentage,
    flat
}

[CreateAssetMenu(fileName = "New Card Add On",
                 menuName = "Factory/Card Add On")]
public class CardAddOnSO : ScriptableObject
{
    [Header("Basic Info")]
    public string cardName;

    [TextArea]
    public string description;

    public Sprite sprite;

    [Header("Effects")]
    public AddOnType profitType;
    public float profitAddOnValue;
    public AddOnType wasteType;
    public float wasteAddOnValue;
}