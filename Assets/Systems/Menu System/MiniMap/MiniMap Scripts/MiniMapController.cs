using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.AI;
public class MiniMapBehavior : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] CanvasGroup MiniMapGroup;
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
        var minimapAction = _playerInput.actions["MiniMapToggle"];

        if (minimapAction == null)
        {
            Debug.LogError("MiniMapToggle action not found!");
            yield break;
        }

        minimapAction.performed += ToggleMiniMap;
        Debug.Log("MiniMapController successfully bound to MiniMapToggle input");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleMiniMap(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("ToggleMiniMap called");
        if (MiniMapGroup.alpha == 1f)
        {
            MiniMapGroup.alpha = 0f;
        }
        else
        {
            MiniMapGroup.alpha = 1f;
        }
    }
}
