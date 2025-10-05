using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenuButtons : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    private static bool isPaused = false;
    private static StarterAssetsInputs _playerMovement;

    private void Awake()
    {
        _cursorControl = new CursorControl();
        _playerMovement = PlayerReference.Instance.Player.GetComponent<StarterAssetsInputs>();
    }
    private static void SetPauseState(bool state)
    {
        PauseMenuReference.Instance.gameObject.SetActive(state);
        isPaused = state;
    }
    public static bool IsPausedCheck()
    {
        return isPaused;
    }

    public static void PauseGame()
    {
        if (PauseMenuReference.Instance != null)
        {
            SetPauseState(true);
        }
        _playerMovement.StopMovement();
        Time.timeScale = 0f;
        isPaused = true;
        GameUIReference.Instance.gameObject.GetComponent<CanvasGroup>().alpha = 0f;
    }

    public static void ResumeGame()
    {
        if (PauseMenuReference.Instance != null)
        {
            SetPauseState(false);
        }
        CursorControl.CursorDeactivate();
        Time.timeScale = 1f;
        isPaused = false;
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
        GameUIReference.Instance.gameObject.GetComponent<CanvasGroup>().alpha = 1f;
        
    }

    public static void MainMenu()
    {
        CursorControl.CursorActivate();
        Time.timeScale = 1f;
        isPaused = false;
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
