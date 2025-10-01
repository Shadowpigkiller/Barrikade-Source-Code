using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
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
    private void Awake()
    {
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

    private void DoInteract(InputAction.CallbackContext callbackContext)
    {
        //Debug.Log("Interact");
        if (!Physics.Raycast(_transform.position + Vector3.up + (_transform.forward * 0.2f), _transform.forward, out var hit, 1.5f, interactableLayer)) return;

        if (!hit.transform.TryGetComponent(out IInteractable interactable)) return;
        interactable.Interact();
        Debug.Log("Interact");
    }
}
