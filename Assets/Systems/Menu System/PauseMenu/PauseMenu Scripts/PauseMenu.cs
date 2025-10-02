using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private PlayerInput _playerInput;
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        _playerInput.actions["Pause"].performed += SetGameState;
    }

    private void OnDisable()
    {
        _playerInput.actions["Pause"].performed -= SetGameState;
    }

    public void SetGameState(InputAction.CallbackContext callbackContext)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
