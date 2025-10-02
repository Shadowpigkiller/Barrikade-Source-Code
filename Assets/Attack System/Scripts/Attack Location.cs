using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AttackLocation : MonoBehaviour
{
    [SerializeField] private GameObject areaTimer;
    private GameObject areaTimerClone;
    private TextMeshProUGUI attackTimerText;
    private Camera _mainCamera;
    [SerializeField] private int NAB_Required;
    [SerializeField] private bool attackActive;
    [SerializeField] private float attackDurationTimer; //current time
    [SerializeField] private float maxAttackDuration; //starting time
    [SerializeField] private int locationIdentifier;

    void Start()
    {
        attackDurationTimer = maxAttackDuration;
        _mainCamera = Camera.main;
    }

    public void ActivateAttack()
    {
        attackActive = true;
    }

    public void DecativateAttack()
    {
        attackActive = false;
    }

    public int GetLocationIdentifier()
    {
        return locationIdentifier;
    }

    // Update is called once per frame
    private void Update()
    {
        //Stop Counting if attack is not active
        if (attackActive == true)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        //Create timer for attack area if one doesn't exist
        if (areaTimerClone == null)
        {
            areaTimerClone = Instantiate(areaTimer, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z), transform.rotation, gameObject.transform);
            attackTimerText = areaTimerClone.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        UpdateTimerCamera();

        //Counts attack timer down and if it reaches 0 the player loses
        if (attackDurationTimer <= 0)
        {
            GameObject.FindWithTag("AttackControllerObject").GetComponent<LoseScreenScript>().ShowLoseScreen(true);
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
