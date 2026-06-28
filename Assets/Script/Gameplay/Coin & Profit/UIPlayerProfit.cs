using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIPlayerProfit : MonoBehaviour
{
    
    [SerializeField] private Slider profitBar;
    [SerializeField] private TMP_Text currProfitText;


    public void UpdatePlayerProfitUI(float currProfit, float maxProfit)
    {
        profitBar.maxValue = maxProfit;
        profitBar.value = currProfit;
        currProfitText.text = $"$ : {currProfit.ToString()}";
    }
}
