using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemScript : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ProductionSO productionSO;

    [Header("UI")]
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text itemPrice;


    public void SetUp(ProductionSO productionSO)
    {
        this.productionSO = productionSO;
        itemName.text = productionSO.productionName;
        iconImage.sprite = productionSO.sprite;
        itemPrice.text = $"$ : {productionSO.productionPrice.ToString()}";
    }

    public void OpenDescription()
    {
        ShopManager.instance.OpenDescription(productionSO);
    }
}
