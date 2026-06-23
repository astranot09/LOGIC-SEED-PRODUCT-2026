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

    [SerializeField] private float polutionDuration;
    [SerializeField] private float profitDuration;


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
}
