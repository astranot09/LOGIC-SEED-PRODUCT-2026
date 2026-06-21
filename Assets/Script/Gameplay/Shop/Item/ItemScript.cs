using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemScript : MonoBehaviour
{
    //productionSO

    [Header("UI")]
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text itemPrice;


    public void SetUp()
    {
        itemName.text = string.Empty;
        iconImage.sprite = null;
        itemPrice.text = string.Empty;
    }

    public void OpenDescription()
    {
        ShopManager.instance.OpenDescription();
    }
}
