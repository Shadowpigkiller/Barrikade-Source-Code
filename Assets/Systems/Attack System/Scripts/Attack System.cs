using TMPro;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    //AttackAreas
    public GameObject attackAreasParent;
    private GameObject[] attackAreasChildren;
    private GameObject activeArea = null;
    private int noRepeat;
    //Timers display
    public GameObject areaTimer;
    private GameObject areaTimerClone;
    private TextMeshProUGUI attackTimerText;
    public float _textOffsetY = 1f;
    private Camera _mainCamera;
    //Timer increment
    private float attackTime = 30f;
    private float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Gets interger amount of the children in Parent object
        attackAreasChildren = new GameObject[attackAreasParent.transform.childCount];
        //Uses integer to loop trhough the children in parent object and assign them to a position in attackAreasChildren Array
        for (int i = 0; i < attackAreasChildren.Length; i++)
        {
            attackAreasChildren[i] = attackAreasParent.transform.GetChild(i).gameObject;
        }
        timer = attackTime;

        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        //Activate random area and spawn timer
        if (activeArea == null)
        {
            //if the same area is chosen choose another
            int randomArea = Random.Range(0, attackAreasChildren.Length);
            while (noRepeat == randomArea)
            { 
                randomArea = Random.Range(0, attackAreasChildren.Length);
            }
            noRepeat = randomArea;

            activeArea = attackAreasChildren[randomArea];
            areaTimerClone = Instantiate(areaTimer, new Vector3(activeArea.transform.position.x, activeArea.transform.position.y + _textOffsetY, activeArea.transform.position.z), transform.rotation, activeArea.transform);
            attackTimerText = areaTimerClone.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }

        //make text face camera
        Vector3 directionToCamera = _mainCamera.transform.position - areaTimerClone.transform.position;
        directionToCamera.y = 0; //keep text upright

        Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);
        areaTimerClone.transform.rotation = targetRotation;

        //decrease timer
        if (timer >= 0)
        {
            attackTimerText.text = Mathf.FloorToInt(timer).ToString();
            timer -= Time.deltaTime;
        }
        else
        {
            //reset timer and set active area to null
            //activeArea = null;
            //Destroy(areaTimerClone);
            //timer = attackTime;

            //Show game over screen and halt player input
            gameObject.GetComponent<LoseScreenScript>().ShowLoseScreen(true);
        }
    }
}
