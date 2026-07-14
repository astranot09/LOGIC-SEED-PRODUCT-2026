using UnityEngine;

public class LoseScript : MonoBehaviour
{
    public static LoseScript instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private GameObject losePanel;

    public void PlayerLose()
    {
        losePanel.SetActive(true);
    }
    public void RestartGame()
    {
        losePanel.SetActive(false);
        SceneController.instance.GameplayScene();
    }
    public void BackToMainMenu()
    {
        losePanel.SetActive(false);
        SceneController.instance.MainMenuScene();
    }
}
