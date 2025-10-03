using UnityEngine;

public class GameUIReference : MonoBehaviour
{
    public static GameUIReference Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // avoid duplicates
            return;
        }

        Instance = this;

        // Optional: keep across scenes
        // DontDestroyOnLoad(gameObject);

        // Make sure menu starts hidden
        gameObject.SetActive(true);
    }
}
