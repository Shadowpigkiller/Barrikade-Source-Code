using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using System.Collections;
public class TutorialController : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    private static StarterAssetsInputs _playerMovement;
    private static bool isPaused = true;
    
    private PlayerInput _playerInput;

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
        CursorControl.CursorActivate();
        _playerMovement.StopMovement();
        PlayerReference.Instance.Player.GetComponent<AudioSource>().enabled = false;
        Time.timeScale = 0f;
        Debug.Log("TutorialController Succesfully Ran");
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
        
    }
}
