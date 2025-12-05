using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEditor.SettingsManagement;
public class TutorialController : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    private static StarterAssetsInputs _playerMovement;
    private static bool isPaused = true;
    private bool AttackPopUp = true;
    [SerializeField] public GameObject AttackPopUpObject;
    [SerializeField] public GameObject tutorialBackground;
    private PlayerInput _playerInput;
    [SerializeField] public GameObject itemPopUpOject;
    [SerializeField] public GameObject RedoOrPlayObject;
    private static bool ItemPopUp = false;
    private static bool barrikadeSystemPopUpDone = false;
    void Awake()
    {
        _cursorControl = new CursorControl();
        if (PlayerReference.Instance != null && PlayerReference.Instance.Player != null)
        {
            _playerInput = PlayerReference.Instance.Player.GetComponent<PlayerInput>();
        }
        else
        {
            Debug.LogWarning("PlayerReference not ready in Awake, delaying init...");
            StartCoroutine(WaitForPlayerRef());
        }

        if (_playerMovement == null)
        {
            if (PlayerReference.Instance != null && PlayerReference.Instance.Player != null)
            {
                _playerMovement = PlayerReference.Instance.Player.GetComponent<StarterAssetsInputs>();
            }
            else
            {
                Debug.LogError("PlayerReference called before _platerMovement was initialized!");
                return;
            }
        }
        isPaused = true;
        PlayerReference.Instance.Player.GetComponent<FirstPersonController>().FreezePlayer();
        CursorControl.CursorActivate();
        OverallCountDownTimer.SetTutorialTime(true);
        RedoOrPlayObject.SetActive(false);
    }

    IEnumerator WaitForPlayerRef()
    {
        yield return new WaitUntil(() => PlayerReference.Instance != null && PlayerReference.Instance.Player != null);
        _playerInput = PlayerReference.Instance.Player.GetComponent<PlayerInput>();

        if (_playerInput == null)
        {
            Debug.LogError("PlayerInput not found on PlayerReference.Player!");
            yield break;
        }
        Debug.Log("TutorialController Succesfully Ran");
    }
    public static bool IsPausedCheck()
    {
        return isPaused;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (NAB_Player_Controller.getNAB_Amount() == 5 && AttackPopUp)
        {
            AttackPopUpObject.SetActive(true);
            PlayerReference.Instance.Player.GetComponent<FirstPersonController>().FreezePlayer();
            tutorialBackground.SetActive(true);
            AttackPopUp = false;
        }
        if (OverallCountDownTimer.getTutorialFinished())
        {
            OpenRedoOrPlay();
            SettingsScript.SetDifficultyCompleted(0);
        }
    }

    public static void StopTime()
    {
        Time.timeScale = 0f;
    }

    public static void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void openItemPopUp()
    {
        if (!ItemPopUp && barrikadeSystemPopUpDone)
        {
            tutorialBackground.SetActive(true);
            itemPopUpOject.SetActive(true);
            ItemPopUp = true;
            PlayerReference.Instance.Player.GetComponent<FirstPersonController>().FreezePlayer();
        }    
    }

    public void setBarrikadeSystemPopUpDone()
    {
        barrikadeSystemPopUpDone = true;
    }

    public void OpenRedoOrPlay()
    {
        RedoOrPlayObject.SetActive(true);
        tutorialBackground.SetActive(true);
        PlayerReference.Instance.Player.GetComponent<FirstPersonController>().FreezePlayer();
        StopTime();
        OverallCountDownTimer.SetTutorialFinsished(false);
        
    }

    public void ReloadTutorial()
    {
        StartCoroutine(ReloadSceneWithDisable());
    }

    private IEnumerator ReloadSceneWithDisable()
    {
        //AttackPopUp = true;
        ItemPopUp = false;
        barrikadeSystemPopUpDone = false;
        isPaused = true;
        RedoOrPlayObject.SetActive(false);
        OverallCountDownTimer.SetTutorialFinsished(false);
        ResumeTime();
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
