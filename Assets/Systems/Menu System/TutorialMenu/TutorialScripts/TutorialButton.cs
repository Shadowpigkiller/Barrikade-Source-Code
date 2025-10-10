using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        CursorControl.CursorDeactivate();
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
        NAB_Player_Controller.SetNAB(0);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
