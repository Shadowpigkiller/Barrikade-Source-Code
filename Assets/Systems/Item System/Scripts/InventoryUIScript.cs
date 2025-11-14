using UnityEngine;
using UnityEngine.UI;

public class InventoryUIScript : MonoBehaviour
{
    [HideInInspector] private Sprite[] inventorySprite;
    [HideInInspector] private Sprite[] itemSprites;
    [SerializeField] GameObject showItemPrefab;
    [SerializeField] int offset = 35;
    private GameObject[] slots;
    private Sprite currentSprite;
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        inventorySprite = Resources.LoadAll<Sprite>("InventorySprites");
        itemSprites = Resources.LoadAll<Sprite>("ItemSprites");
        slots = new GameObject[2];

    }
    public Sprite ChangeSprite(int _index)
    {
        currentSprite = inventorySprite[_index];
        return currentSprite;
    }

    public void ShowItems(int slot1, int slot2)
    {
        //Slot1 and slot2 are whatever item is in those two inventory slots
        if (slot1 != (int)UseItemScript.Items.None)
        {
            if (!slots[0])
            {
                slots[0] = Instantiate(
                showItemPrefab,
                new Vector3(
                    transform.position.x,
                    transform.position.y + offset,
                    transform.position.z),
                    Quaternion.identity,
                    transform
                );
                slots[0].GetComponent<Image>().sprite = itemSprites[slot1];
            }

        }

        if (slot2 != (int)UseItemScript.Items.None)
        {
            if (!slots[1])
            {
                slots[1] = Instantiate(
                showItemPrefab,
                new Vector3(
                    transform.position.x,
                    transform.position.y - offset,
                    transform.position.z),
                    Quaternion.identity,
                    transform
                );
                slots[1].GetComponent<Image>().sprite = itemSprites[slot2];
            }

        }
    }

    public void RemoveItems(int selector)
    {
        if (slots[selector])
            {
                Destroy(slots[selector].gameObject);
            }
    }
}
