using UnityEngine;

[CreateAssetMenu(fileName = "StaminaSpriteSet", menuName = "UI/StaminaSpriteSet")]
public class StaminaSpriteSet : ScriptableObject
{
    [HideInInspector] private Sprite[] sprites;
}
