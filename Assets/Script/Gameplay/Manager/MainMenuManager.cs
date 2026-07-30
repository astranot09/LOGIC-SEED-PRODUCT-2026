using UnityEngine;

public class MainMenuManager : MonoBehaviour
{


    [SerializeField] private GameObject creditPanel;
    public void PlayGame()
    {
        SceneController.instance.GameplayScene();
    }

    public void OpenSettings()
    {

    }

    public void OpenCredits()
    {
        creditPanel.SetActive(!creditPanel.activeSelf);
    }

    public void ExitGame()
    {
        //if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //else
        Application.Quit();
        //endif
    }
}