using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneController.instance.GameplayScene();
    }

    public void OpenSettings()
    {

    }

    public void OpenCredits()
    {

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