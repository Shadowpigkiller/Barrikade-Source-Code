using UnityEngine;
using UnityEngine.InputSystem;

public class WinLoseScript : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public PlayerInput playerMap;
    [HideInInspector] public CursorControl _cursorControl;
    [SerializeField] public AudioClip EndSound;
    [SerializeField] public AudioClip WinSound;
    [SerializeField] public AudioSource audioSource;
    void Awake()
    {
        _cursorControl = new CursorControl();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    public void ShowLoseScreen(bool toggle)
    {
        playerMap.actions.Disable();
        gameOverCanvas.SetActive(toggle);
        Time.timeScale = 0f;
        if (GameObject.FindWithTag("Game UI") != null)
        {
            GameObject.FindWithTag("Game UI").SetActive(false);
        }
        CursorControl.CursorActivate();
        audioSource.PlayOneShot(EndSound);
    }

    public void ShowWinScreen(bool toggle)
    {
        playerMap.actions.Disable();
        gameObject.GetComponent<AttackController>().enabled = false;
        winCanvas.SetActive(toggle);
        Time.timeScale = 0f;
        if (GameObject.FindWithTag("Game UI") != null)
        {
            GameObject.FindWithTag("Game UI").SetActive(false);
        }
        CursorControl.CursorActivate();
        audioSource.PlayOneShot(WinSound);
    }
}
