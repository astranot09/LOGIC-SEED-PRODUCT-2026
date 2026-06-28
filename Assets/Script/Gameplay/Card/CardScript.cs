using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardScript : MonoBehaviour
{

    [SerializeField] private CardAddOnSO cardAddOnSO;
    [SerializeField] private Image iconCard;
    [SerializeField] private TMP_Text nameCard;
    [SerializeField] private TMP_Text descriptionCard;

    public void SetUp(CardAddOnSO cardAddOnSO)
    {
        if(cardAddOnSO != null)
            this.cardAddOnSO = cardAddOnSO;

        if (cardAddOnSO.sprite != null)
            iconCard.sprite = cardAddOnSO.sprite;

        if(cardAddOnSO.cardName != null)
            nameCard.text = cardAddOnSO.cardName;

        if(cardAddOnSO.description != null)
            descriptionCard.text = cardAddOnSO.description;
    }

    public void ChooseThisCard()
    {
        CardManager.instance.SelectThisCard(cardAddOnSO);
    }
}
