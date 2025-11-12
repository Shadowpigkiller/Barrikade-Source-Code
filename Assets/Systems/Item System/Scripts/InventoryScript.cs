using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private bool[] hasItem = new bool[(int)UseItemScript.Items.None];
    [HideInInspector] public UseItemScript.Items[] inventory = new UseItemScript.Items[2];
    [Header ("Inventory UI Elements")]
    [SerializeField] private Image inventorySlotSelected;
    [SerializeField] InventoryUIScript _inventoryUIScript;
    private int selector = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        inventory[0] = UseItemScript.Items.None;
        inventory[1] = UseItemScript.Items.None;
    }

    void OnEnable()
    {
        _playerInput.actions["UseItem"].performed += UseItems;
        _playerInput.actions["CycleInventory"].performed += CyclePlayerInventory;
    }
    void OnDisable()
    {
        _playerInput.actions["UseItem"].performed -= UseItems;
        _playerInput.actions["CycleInventory"].performed -= CyclePlayerInventory;
    }

    public void CollectItem(string item)
    {
        int value = 0;
        UseItemScript.Items collected = UseItemScript.Items.None;
        switch (item)
        {
            case "WatchItem":
                value = 0;
                collected = UseItemScript.Items.Watch;
                break;
            case "SyringeItem":
                value = 1;
                collected = UseItemScript.Items.Syringe;
                break;
            case "RevolverItem":
                value = 2;
                collected = UseItemScript.Items.Revolver;
                break;
            case "CrossedNailsItem":
                value = 3;
                collected = UseItemScript.Items.CrossedNails;
                break;
            default:
                collected = UseItemScript.Items.None;
                break;
        }
        hasItem[value] = true;
        if (inventory[0] == UseItemScript.Items.None)
        {
            inventory[0] = collected;
        }
        else
        {
            inventory[1] = collected;
        }
        _inventoryUIScript.ShowItems((int)inventory[0], (int)inventory[1]);
    }

    private void UseItems(InputAction.CallbackContext callbackContext)
    {
        UseItemScript.UseItem(inventory[selector]);
        inventory[selector] = UseItemScript.Items.None;
        _inventoryUIScript.RemoveItems(selector);
    }

    private void CyclePlayerInventory(InputAction.CallbackContext callbackContext)
    {
        selector = selector < inventory.Length - 1 ? selector + 1 : 0;
        inventorySlotSelected.sprite = _inventoryUIScript.ChangeSprite(selector);
    }
}
