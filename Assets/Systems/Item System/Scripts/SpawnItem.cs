using System;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private GameObject currItem;
    public void LoadItem(GameObject item)
    {
        currItem = item;
        Instantiate(item, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
    }

    public void UpdateValues()
    {
        //update norepeat and spawned items
        this.transform.parent.GetComponent<ItemSpawnController>().spawnedItems.Remove(currItem);
        this.transform.parent.GetComponent<ItemSpawnController>().noRepeat[transform.GetSiblingIndex()] = false;
    }
}
