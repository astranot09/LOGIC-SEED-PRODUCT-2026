using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public static CardManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private float polutionMultiplier = 1f;
    [SerializeField] private float profitMultiplier = 1f;

    [Header("Card Setting")]
    [SerializeField] private List<CardAddOnSO> cardSOData = new();
    [SerializeField] private int cardSpawn = 3;

    [Header("UI")]
    [SerializeField] private GameObject cardSpawnerPanel;
    [SerializeField] private Transform cardSpawner;
    [SerializeField] private GameObject cardPrefab;

    [Header("Reference")]
    [SerializeField] private PlayerProfitScript profitScript;

    public float FinalPolutionCalculation(float x)
    {
        float calcu = x * polutionMultiplier;
        return calcu;
    }
    public float FinalProfitCalculation(float x)
    {
        float calcu = x * polutionMultiplier;
        return calcu;
    }


    private void AddPolutionMultiplier(float x)
    {
        polutionMultiplier += x/100;
    }
    private void AddProfitMultiplier(float x)
    {
        polutionMultiplier += x/100;
    }

    private void RemovePolution(int x)
    {
        WasteManager.Instance.RemoveWaste(x);
    }


    public void ChangeProfitIntoCard()
    {
        profitScript.RemoveProfit(profitScript.MaxProfit);
        profitScript.UpdateMaximumProfitToChangeCard();
        CardSpawnSetUp();
    }
    public void CardSpawnSetUp()
    {
        cardSpawnerPanel.SetActive(true);
        if(cardSpawner.childCount > 0)
        {
            for (int i = cardSpawner.childCount - 1; i >= 0; i--)
            {
                Destroy(cardSpawner.GetChild(i).gameObject);
            }
        }

        List<CardAddOnSO> selectedCards = randomCardAddOn();

        for (int i = 0; i < selectedCards.Count; i++)
        {
            GameObject x = Instantiate(cardPrefab, cardSpawner);

            CardScript cardScript = x.GetComponent<CardScript>();
            if (cardScript != null)
            {
                cardScript.SetUp(selectedCards[i]);
            }
        }
        SoundManager.instance.PlaySFX(SoundManager.instance.cardSummon);

    }

    private List<CardAddOnSO> randomCardAddOn()
    {
        // FIXED: Created an actual COPY of the list so we don't alter the original Inspector list
        List<CardAddOnSO> pool = new List<CardAddOnSO>(cardSOData);
        List<CardAddOnSO> currCardData = new();

        // Loop until we hit our target spawn count OR run out of unique cards
        for (int i = 0; i < cardSpawn; i++)
        {
            if (pool.Count == 0) break; // Safety check if pool has fewer cards than cardSpawn

            int index = Random.Range(0, pool.Count);
            currCardData.Add(pool[index]);

            // Remove the card from our temporary pool so it can't be chosen again this round
            pool.RemoveAt(index);
        }

        return currCardData;
    }


   public void SelectThisCard(CardAddOnSO card)
    {
        ReadCardSO(card);
        cardSpawnerPanel.SetActive(false);
    }


    public void ReadCardSO(CardAddOnSO cardAddOnSO)
    {
        if(cardAddOnSO == null) return;

        if(cardAddOnSO.wasteType == AddOnType.percentage)
        {
            AddPolutionMultiplier(cardAddOnSO.wasteAddOnValue);
        }
        if (cardAddOnSO.wasteType == AddOnType.flat)
        {
            RemovePolution((int)cardAddOnSO.wasteAddOnValue); 
        }
        if (cardAddOnSO.profitType == AddOnType.percentage)
        {
            AddProfitMultiplier(cardAddOnSO.profitAddOnValue);
        }
    }
}
