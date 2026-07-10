using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {

    }

    public void OpenSettings()
    {

    }

    public void OpenCredits()
    {

    }

    public void ExitGame()
    {
        Debug.Log(-1);

//if UNITY_EDITOR
//        UnityEditor.EditorApplication.isPlaying = false;
//else
//        Application.Quit();
//endif
    }
}