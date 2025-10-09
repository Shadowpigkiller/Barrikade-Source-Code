using UnityEngine;
using UnityEngine.UI;

public class StaminaUIController : MonoBehaviour
{
    [HideInInspector] private Sprite[] spineSprite;
    private Sprite currentSprite;
    private SpriteRenderer _spriteRenderer;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        spineSprite = Resources.LoadAll<Sprite>("Resource UI Sprites/StaminaSprites");
    }
    public Sprite ChangeSprite(int _index)
    {
        currentSprite = spineSprite[_index];
        return currentSprite;
    }
}
