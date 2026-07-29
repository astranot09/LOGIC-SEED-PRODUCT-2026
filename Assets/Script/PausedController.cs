using UnityEngine;
using UnityEngine.InputSystem;

public class PausedController : MonoBehaviour
{
    [SerializeField] private GameObject pausedPanel;

    public void OnPaused(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Paused();
        }
    }


    public void Paused()
    {
        pausedPanel.SetActive(!pausedPanel.activeSelf);
        //if (pausedPanel.activeSelf)
        //{
        //    Time.timeScale = 0f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}
    }

}
