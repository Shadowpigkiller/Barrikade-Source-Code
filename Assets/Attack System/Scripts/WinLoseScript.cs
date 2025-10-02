using UnityEngine;
using UnityEngine.InputSystem;

public class WinLoseScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
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

    public void ShowWinScreen(bool toggle)
    {
        playerMap.actions.Disable();
        gameObject.GetComponent<AttackSystem>().enabled = false;
        winCanvas.SetActive(toggle);
    }
}
