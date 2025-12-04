using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    [SerializeField] public GameObject journal1;
    [SerializeField] public GameObject journal2;
    [SerializeField] public GameObject journal3;
    [SerializeField] public GameObject journal4;
    [SerializeField] public GameObject journal5;
    [SerializeField] public GameObject journal6;

    public void Awake()
    {
        if (SettingsScript.GetDifficultyCompleted() == 4)
        {
            journal1.GetComponent<Button>().interactable = true;
            journal2.GetComponent<Button>().interactable = true;
            journal3.GetComponent<Button>().interactable = true;
            journal4.GetComponent<Button>().interactable = true;
            journal5.GetComponent<Button>().interactable = true;
            journal6.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 3)
        {
            journal1.GetComponent<Button>().interactable = true;
            journal2.GetComponent<Button>().interactable = true;
            journal3.GetComponent<Button>().interactable = true;
            journal4.GetComponent<Button>().interactable = true;
            journal5.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 2)
        {
            journal1.GetComponent<Button>().interactable = true;
            journal2.GetComponent<Button>().interactable = true;
            journal3.GetComponent<Button>().interactable = true;
            journal4.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 1)
        {
            journal1.GetComponent<Button>().interactable = true;
            journal2.GetComponent<Button>().interactable = true;
            journal3.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 0)
        {
            journal1.GetComponent<Button>().interactable = true;
            journal2.GetComponent<Button>().interactable = true;
        }
        else{}
    }
    void Start()
    {
        _cursorControl = new CursorControl();
    }

    public void PlayGame()
    {
        NAB_Player_Controller.SetNAB(0);
        int difficulty = SettingsScript.getDifficulty();
        CursorControl.CursorDeactivate();
        OverallCountDownTimer.SetTutorialTime(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(difficulty);
        PauseMenuButtons.SetPauseState(false);
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTutorial()
    {
        NAB_Player_Controller.SetNAB(0);
        CursorControl.CursorDeactivate();
        Time.timeScale = 1f;
        SceneManager.LoadScene(5);
        if (PlayerReference.Instance != null)
        {
            PlayerReference.Instance.gameObject.SetActive(true);
        }
    }
}
