using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    void Start()
    {
        _cursorControl = new CursorControl();
    }

    public void PlayGame()
    {
        int difficulty = SettingsScript.getDifficulty();
        CursorControl.CursorDeactivate();
        SceneManager.LoadScene(difficulty);
        Time.timeScale = 1f;
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
        NAB_Player_Controller.SetNAB(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTutorial()
    {
        CursorControl.CursorDeactivate();
        SceneManager.LoadScene(5);
        Time.timeScale = 1f;
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
        NAB_Player_Controller.SetNAB(0);
    }
}
