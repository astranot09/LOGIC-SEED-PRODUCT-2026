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
    public List<GameObject> allItems = new List<GameObject>(); //nanti diganti jadi produksiSO

    [Header("ShopSpawner")]
    [SerializeField] private Transform shopSpawner;

    [Header("Description")]
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemDescription;
    [SerializeField] private Transform polutionRateSpawner;
    //[SerializeField] private GameObject polutionRatePrefab;
    [SerializeField] private Transform profitRateSpawner;
    //[SerializeField] private GameObject profitRatePrefab;

    public void OpenShop()
    {
        if (shopSpawner.childCount > 0)
        {
            for (int i = shopSpawner.childCount - 1; i >= 0; i--)
            {
                Destroy(shopSpawner.GetChild(i).gameObject);
            }
        }
        foreach (var item in allItems)
        {
            Instantiate(item, shopSpawner);
            item.GetComponent<ItemScript>().SetUp(); //ntar isi SetUp tambah prouctionSO
        }
    }


    public void OpenDescription()
    {
        itemName.text = string.Empty;
        itemIcon.sprite = null;
        itemDescription.text = string.Empty;

        //RESET Polution
        for (int i = polutionRateSpawner.childCount - 1; i >= 0; i--)
        {
            polutionRateSpawner.GetChild(i).gameObject.SetActive(false);
            //Destroy(polutionRateSpawner.GetChild(i).gameObject);
        }

        for (int i = 0; i < allItems.Count; i++)
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

        for (int i = 0; i < allItems.Count; i++)
        {
            profitRateSpawner.GetChild(i).gameObject.SetActive(true);
            //Instantiate(profitRatePrefab, profitRateSpawner);
        }
    }

}
