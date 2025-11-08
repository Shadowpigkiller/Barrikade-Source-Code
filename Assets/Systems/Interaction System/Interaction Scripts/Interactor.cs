using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;
interface IInteractable
{
    public UnityEvent onInteract {get; protected set;}
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    private PlayerInput _playerInput;
    private Transform _transform;
    [SerializeField] GameObject playerCursor;

    GameObject playerObject;
    private void Awake()
    {
        playerObject = GameObject.Find("PlayerCapsule");
        _transform = transform;
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += DoInteract;
    }

    private void OnDisable()
    {
        _playerInput.actions["Interact"].performed -= DoInteract;
    }

    private void Update()
    {
        if (Physics.Raycast(_transform.position + Vector3.up + (_transform.forward * 0.2f), _transform.forward, out var hit, 2.5f, interactableLayer))
        {
            playerCursor.GetComponent<Image>().color = new Color32(134, 0, 243, 255);
        }
        else
        {
            playerCursor.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (UseItemScript.crossedNails == true)
        {
            _playerInput.actions["UseItem"].performed += DoInteract;
        }
    }
    private void DoInteract(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.action == _playerInput.actions["UseItem"])
        {
            UseItemScript.crossedNails = false;
            _playerInput.actions["UseItem"].performed -= DoInteract;
            Debug.Log("callbacked");
            UseItemScript.crossPressed = true;
        }
        Debug.Log(callbackContext.action == _playerInput.actions["Interact"]);
        if (!Physics.Raycast(_transform.position + Vector3.up + (_transform.forward * 0.2f), _transform.forward, out var hit, 2.5f, interactableLayer)) return;
        if (!hit.transform.TryGetComponent(out IInteractable interactable)) return;
        interactable.Interact();
        Debug.Log("Interact");
    }
}
