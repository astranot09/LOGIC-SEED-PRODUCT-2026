using UnityEngine;

public class PlayerProfitScript : MonoBehaviour
{
    [SerializeField] private float playerProfit;


    public void AddProfit(float profit)
    {
        playerProfit += profit;
    }

    public void RemoveProfit(float value)
    {
        if (CheckProfit(value))
        {
            playerProfit -= value;
        }
    }


    private bool CheckProfit(float value)
    {
        if((playerProfit - value) < 0)
        {
            return false;
        }
        return true;
    }
}
