using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 130.0f;
    [SerializeField] private float maxStamina = 130.0f;
    [HideInInspector] public bool weAreSprinting = false;
    [HideInInspector] public bool hasRegenerated = true;

    [Header("Stamina Regen Parameters")]
    [Range(0, 50)][SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;
    private float originalStaminaDrainValue;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI;
    [SerializeField] private StaminaUIController _staminaUIController;

    private FirstPersonController playerController;
    private StarterAssetsInputs _input;
    [HideInInspector] public bool unlockSprint = true;
    private void Start()
    {
        originalStaminaDrainValue = staminaDrain;
        playerController = GetComponent<FirstPersonController>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (!weAreSprinting)
        {
            if (playerStamina <= maxStamina)
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
        staminaDrain = UseItemScript.syringeActive ? UseItemScript.syringeDrain : originalStaminaDrainValue;
        //Debug.Log(playerStamina);
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
        staminaProgressUI.sprite = _staminaUIController.ChangeSprite((int) playerStamina / 10);
    }
}
