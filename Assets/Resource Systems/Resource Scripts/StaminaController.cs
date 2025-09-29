using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [HideInInspector] public bool weAreSprinting = false;
    [HideInInspector] public bool hasRegenerated = true;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)][SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private FirstPersonController playerController;
    private StarterAssetsInputs _input;
    [HideInInspector] public bool unlockSprint = true;
    private void Start()
    {
        playerController = GetComponent<FirstPersonController>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (!weAreSprinting)
        {
            if (playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina();

                if (playerStamina >= (maxStamina * 0.30))
                {
                    playerController.setRunSpeed(playerController.MoveSpeed);
                    hasRegenerated = true;
                }
            }
            if (_input.sprint == false)
            {
                unlockSprint = true;
            }
        }
    }

    public void Sprinting()
    {
        if (hasRegenerated)
        {
            weAreSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina();

            if (playerStamina <= 0)
            {
                hasRegenerated = false;
                weAreSprinting = false;
                playerController.setRunSpeed(playerController.MoveSpeed);
                unlockSprint = false;
            }
        }
    }

    void UpdateStamina()
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;
    }
}
