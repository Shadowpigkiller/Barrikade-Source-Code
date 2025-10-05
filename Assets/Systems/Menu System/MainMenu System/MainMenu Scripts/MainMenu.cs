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
        CursorControl.CursorDeactivate();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
