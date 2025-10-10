using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    [HideInInspector] public CursorControl _cursorControl;
    private PlayerInput _playerInput;
    void Awake()
    {
        _playerInput = PlayerReference.Instance.Player.GetComponent<PlayerInput>();
    }
    void OnEnable()
    {
        if (_playerInput != null)
        {
            _playerInput.actions.Enable();
            _playerInput.actions["Pause"].performed += SetGameState;
        }
        Debug.Log("OnEnableEnd");
    }
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
