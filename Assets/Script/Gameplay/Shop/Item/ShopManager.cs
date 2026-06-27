using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{

    public static ShopManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [Header("Item Database")]
    public List<ProductionSO> allItems = new List<ProductionSO>();

    [Header("ShopPanel")]
    [SerializeField] private GameObject shopPanel;

    [Header("ShopSpawner")]
    [SerializeField] private Transform shopSpawner;
    [SerializeField] private GameObject shopPrefab;

    [Header("Description")]
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemDescription;
    [SerializeField] private Transform polutionRateSpawner;
    [SerializeField] private Transform profitRateSpawner;

    [Header("UI Build")]
    [SerializeField] private GameObject buildPanel;

    [Header("Curr Shop")]
    [SerializeField] private ProductionSO productionCurr;
    public ProductionSO ProductionCurr => productionCurr;

    private void Start()
    {
        allItems.Clear();
        foreach (ProductionSO data in ProductionDatabase.instance.allProductionSO)
        {
            allItems.Add(data);
        }
    }

    public void OpenShop()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        if (!shopPanel.activeSelf)
        {
            buildPanel.SetActive(false);
            productionCurr = null;
        }

        if (shopSpawner.childCount > 0)
        {
            for (int i = shopSpawner.childCount - 1; i >= 0; i--)
            {
                Destroy(shopSpawner.GetChild(i).gameObject);
            }
        }
        foreach (var item in allItems)
        {
            GameObject x = Instantiate(shopPrefab, shopSpawner);
            x.GetComponent<ItemScript>().SetUp(item); //ntar isi SetUp tambah prouctionSO
        }
        ResetShopDescription();
    }


    public void OpenDescription(ProductionSO productionSO)
    {
        productionCurr = productionSO;
        itemName.text = productionSO.productionName;
        itemIcon.sprite = productionSO.sprite;
        itemDescription.text = productionSO.description;

        //RESET Polution
        for (int i = polutionRateSpawner.childCount - 1; i >= 0; i--)
        {
            polutionRateSpawner.GetChild(i).gameObject.SetActive(false);
            //Destroy(polutionRateSpawner.GetChild(i).gameObject);
        }

        for (int i = 0; i < productionSO.pollutionRate; i++)
        {
            polutionRateSpawner.GetChild(i).gameObject.SetActive(true);
            //Instantiate(polutionRatePrefab,polutionRateSpawner);
        }

        //RESET Profit
        for (int i = profitRateSpawner.childCount - 1; i >= 0; i--)
        {
            profitRateSpawner.GetChild(i).gameObject.SetActive(false);
            //Destroy(profitRateSpawner.GetChild(i).gameObject);
        }

        for (int i = 0; i < productionSO.profitRate; i++)
        {
            profitRateSpawner.GetChild(i).gameObject.SetActive(true);
            //Instantiate(profitRatePrefab, profitRateSpawner);
        }

        buildPanel.SetActive(true);
        UIChooseLandToBuild.instance.SetUpUIToChoose();
    }


    public void ResetShopDescription()
    {
        itemName.text = null;
        itemIcon.sprite = null;
        itemDescription.text = null;

        //RESET Polution
        for (int i = polutionRateSpawner.childCount - 1; i >= 0; i--)
        {
            polutionRateSpawner.GetChild(i).gameObject.SetActive(false);
            //Destroy(polutionRateSpawner.GetChild(i).gameObject);
        }


        //RESET Profit
        for (int i = profitRateSpawner.childCount - 1; i >= 0; i--)
        {
            profitRateSpawner.GetChild(i).gameObject.SetActive(false);
            //Destroy(profitRateSpawner.GetChild(i).gameObject);
        }

    }

}
