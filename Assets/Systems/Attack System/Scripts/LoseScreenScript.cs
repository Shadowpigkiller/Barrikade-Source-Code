using UnityEngine;
using UnityEngine.InputSystem;

public class LoseScreenScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public PlayerInput playerMap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public void ShowLoseScreen(bool toggle)
    {
        playerMap.actions.Disable();
        gameOverCanvas.SetActive(toggle);
    }
}
