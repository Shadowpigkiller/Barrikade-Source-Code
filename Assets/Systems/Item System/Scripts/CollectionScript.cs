using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InventoryScript playerInventory = other.GetComponent<InventoryScript>();
        if (playerInventory != null)
        {
            if(playerInventory.inventory[0] == UseItemScript.Items.None || playerInventory.inventory[1] == UseItemScript.Items.None)
            {
                playerInventory.CollectItem(gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
