using UnityEngine;

public class PlayerReference : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Static global reference
    public static PlayerReference Instance { get; private set; }

    // Expose the actual player GameObject
    public GameObject Player { get; private set; }

    void Awake()
    {
        // Enforce singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // optional: prevent duplicates
            return;
        }

        Instance = this;
        Player = gameObject; // the GameObject this script is attached to

        // Optional: make this persist across scenes
        // DontDestroyOnLoad(gameObject);
    }
}
