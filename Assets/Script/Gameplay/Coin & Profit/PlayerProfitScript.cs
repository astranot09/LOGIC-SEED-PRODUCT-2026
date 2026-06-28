using UnityEngine;

public class PlayerProfitScript : MonoBehaviour
{
    [SerializeField] private float playerProfit;
    [SerializeField] private float maxProfit;
    [SerializeField] private UIPlayerProfit uiPlayerProfit;


    private void Start()
    {
        uiPlayerProfit.UpdatePlayerProfitUI(playerProfit, maxProfit);
    }

    public void AddProfit(float profit)
    {
        playerProfit += profit;
        uiPlayerProfit.UpdatePlayerProfitUI(playerProfit, maxProfit);
    }

    public void RemoveProfit(float value)
    {
        if (CheckProfit(value))
        {
            playerProfit -= value;
            uiPlayerProfit.UpdatePlayerProfitUI(playerProfit, maxProfit);
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
}
