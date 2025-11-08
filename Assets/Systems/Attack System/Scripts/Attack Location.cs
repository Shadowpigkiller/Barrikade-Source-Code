using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.Collections;
public class AttackLocation : MonoBehaviour
{
    [SerializeField] private GameObject areaTimer;
    private GameObject areaTimerClone;
    private TextMeshProUGUI attackTimerText;
    private Camera _mainCamera;
    [SerializeField] private int NAB_Required;
    [SerializeField] public bool attackActive;
    [SerializeField] private float attackDurationTimer; //current time
    [SerializeField] private float maxAttackDuration; //starting time
    [SerializeField] private int locationIdentifier;
    [SerializeField] public Text NAB_AmountText;
    [SerializeField] public GameObject MiniMapAttackLocationDot;
    [SerializeField] public AudioClip attackSound;
    [SerializeField] public AudioClip initialAttackSound;
    [SerializeField] private int capsuleOffsetx;
    [SerializeField] private int capsuleOffsety;
    [SerializeField] private int capsuleOffsetz;
    [SerializeField] private float timerOffsetx;
    [SerializeField] private float timerOffsety;
    [SerializeField] private float timerOffsetz;
    GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.Find("PlayerCapsule");
        attackDurationTimer = maxAttackDuration;
        _mainCamera = Camera.main;
    }

    public void ActivateAttack()
    {
        attackActive = true;
        attackDurationTimer = maxAttackDuration;
        MiniMapAttackLocationDot.SetActive(true);
        SpawnCapsule.instance.Activate(transform, locationIdentifier, capsuleOffsetx, capsuleOffsety, capsuleOffsetz);
        AttackAreaMusic.instance.PlaySFX(initialAttackSound, transform, 1);
        AttackAreaMusic.instance.PlayMusic(attackSound, transform, 1, true, locationIdentifier);
    }

    public void DecativateAttack()
    {
        attackActive = false;
        MiniMapAttackLocationDot.SetActive(false);
        SpawnCapsule.instance.Deactivate(locationIdentifier);
        AttackAreaMusic.instance.PlayMusic(attackSound, transform, 1, false, locationIdentifier);
        attackDurationTimer = maxAttackDuration;
        Destroy(areaTimerClone);
    }

    public int GetLocationIdentifier()
    {
        return locationIdentifier;
    }

    // Update is called once per frame
    private void Update()
    {
        //Stop Counting if attack is not active
        if (attackActive == true && !UseItemScript.watchActive)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        //Create timer for attack area if one doesn't exist
        if (areaTimerClone == null)
        {
            areaTimerClone = Instantiate(areaTimer, new Vector3(gameObject.transform.position.x + timerOffsetx, gameObject.transform.position.y + 1f + timerOffsety, gameObject.transform.position.z + timerOffsetz), gameObject.transform.rotation, gameObject.transform);
            attackTimerText = areaTimerClone.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        UpdateTimerCamera();

        //Counts attack timer down and if it reaches 0 the player loses
        if (attackDurationTimer <= 0)
        {
            if (UseItemScript.revolver)
            {
                UseItemScript.revolver = false;
                int selector = playerObject.GetComponent<InventoryScript>().inventory[0] == UseItemScript.Items.Revolver ? 0 : 1;
                playerObject.GetComponent<InventoryScript>().inventory[selector] = UseItemScript.Items.None;
                GameObject.Find("Inventory").GetComponent<InventoryUIScript>().RemoveItems(selector);
                DecativateAttack();
            }
            else
            {
                GameObject.FindWithTag("AttackControllerObject").GetComponent<WinLoseScript>().ShowLoseScreen(true);
            }
            
        }
        else
        {
            attackTimerText.text = Mathf.FloorToInt(attackDurationTimer).ToString();
            attackDurationTimer -= Time.deltaTime;
        }
    }

    public void OnInteract()
    {
        if (NAB_Player_Controller.getNAB_Amount() >= NAB_Required)
        {
            DecativateAttack();
            NAB_Player_Controller.removeNAB(NAB_Required);
            NAB_AmountText.text = Convert.ToString(NAB_Player_Controller.getNAB_Amount());
            Debug.Log("interacted");
        }
    }

    private void UpdateTimerCamera()
    {
        //make text face camera
        Vector3 directionToCamera = _mainCamera.transform.position - areaTimerClone.transform.position;
        directionToCamera.y = 0; //keep text upright

        Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
        areaTimerClone.transform.rotation = targetRotation;
    }
}
