using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PauseMenuController : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    private PlayerInput _playerInput;
    void Awake()
    {
        if (PlayerReference.Instance != null && PlayerReference.Instance.Player != null)
        {
            _playerInput = PlayerReference.Instance.Player.GetComponent<PlayerInput>();
        }
        else
        {
            Debug.LogWarning("PlayerReference not ready in Awake, delaying init...");
            StartCoroutine(WaitForPlayerRef());
        }
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

        // Enable input and subscribe to Pause event
        _playerInput.actions.Enable();
        var pauseAction = _playerInput.actions["Pause"];

        if (pauseAction == null)
        {
            Debug.LogError("Pause action not found!");
            yield break;
        }

        pauseAction.performed += SetGameState;
        Debug.Log("PauseMenuController successfully bound to Pause input");
    }
    /*
    void OnEnable()
    {
        if (_playerInput != null)
        {
            _playerInput.actions.Enable();
            _playerInput.actions["Pause"].performed += SetGameState;
        }
        Debug.Log("OnEnableEnd");
    }
    */
    void OnDisable()
    {
        Debug.Log("OnDisable");
        if (_playerInput != null)
        {
            _playerInput.actions["Pause"].performed -= SetGameState;
        }     
    }

    public void SetGameState(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("SetGameState called");

        Debug.Log("PauseMenuButtons.IsPausedCheck = " + PauseMenuButtons.IsPausedCheck());

        if (PauseMenuButtons.IsPausedCheck())
        {
            Debug.Log("Trying ResumeGame");
            PauseMenuButtons.ResumeGame();
        }
        else
        {
            Debug.Log("Trying CursorActivate");
            CursorControl.CursorActivate();

            Debug.Log("Trying PauseGame");
            PauseMenuButtons.PauseGame();
            Debug.Log("Left PauseGame");
        }
    }
}
