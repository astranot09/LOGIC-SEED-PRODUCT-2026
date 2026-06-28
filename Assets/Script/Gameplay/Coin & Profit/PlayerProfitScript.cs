using System;
using UnityEngine;

public class PlayerProfitScript : MonoBehaviour
{
    [SerializeField] private float playerProfit;


    [Header("Max Profit Setting")]
    public float MaxProfit;
    [SerializeField] private float maxProfit => MaxProfit;
    [SerializeField] private float maxProfitMultiplier;

    [Header("Profit Exchange")]
    public GameObject profitChangePanel;

    [Header("Reference")]
    [SerializeField] private UIPlayerProfit uiPlayerProfit;


    private void Start()
    {
        uiPlayerProfit.UpdatePlayerProfitUI(playerProfit, maxProfit);
    }

    public void AddProfit(float profit)
    {
        playerProfit += profit;
        playerProfit = (float)Math.Round(playerProfit, 2);
        uiPlayerProfit.UpdatePlayerProfitUI(playerProfit, maxProfit);
        CheckPlayerCanChangeProfit();
    }

    public void RemoveProfit(float value)
    {
        if (CheckProfit(value))
        {
            playerProfit -= value;
            playerProfit = (float)Math.Round(playerProfit, 2);
            uiPlayerProfit.UpdatePlayerProfitUI(playerProfit, maxProfit);
            CheckPlayerCanChangeProfit();
        }
    }

    private void CheckPlayerCanChangeProfit()
    {
        if(playerProfit >= maxProfit)
        {
            profitChangePanel.SetActive(true);
        }
        else
        {
            profitChangePanel.SetActive(false);
        }
    }


    public bool CheckProfit(float value)
    {
        if((playerProfit - value) < 0)
        {
            return false;
        }
        return true;
    }


    public void UpdateMaximumProfitToChangeCard()
    {
        MaxProfit *= maxProfitMultiplier;
        uiPlayerProfit.UpdatePlayerProfitUI(playerProfit,maxProfit);
    }
}
