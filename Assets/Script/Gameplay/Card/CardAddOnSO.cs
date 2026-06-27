using UnityEngine;

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
    public float profitAddOn;
    public float wasteAddOn;
}