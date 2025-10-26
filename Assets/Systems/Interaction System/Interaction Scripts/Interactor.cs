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

    private void Update()
    {
        if (Physics.Raycast(_transform.position + Vector3.up + (_transform.forward * 0.2f), _transform.forward, out var hit, 2.5f, interactableLayer))
        {
            playerCursor.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
        }
        else
        {
            playerCursor.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
    }
    private void DoInteract(InputAction.CallbackContext callbackContext)
    {
        if (!Physics.Raycast(_transform.position + Vector3.up + (_transform.forward * 0.2f), _transform.forward, out var hit, 2.5f, interactableLayer)) return;
        if (!hit.transform.TryGetComponent(out IInteractable interactable)) return;
        interactable.Interact();
        Debug.Log("Interact");
    }
}
