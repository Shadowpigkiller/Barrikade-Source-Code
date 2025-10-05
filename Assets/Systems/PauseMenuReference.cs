using UnityEngine;

public class PauseMenuReference : MonoBehaviour
{
   public static PauseMenuReference Instance { get; private set; }
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
        gameObject.SetActive(false);
    }
}
