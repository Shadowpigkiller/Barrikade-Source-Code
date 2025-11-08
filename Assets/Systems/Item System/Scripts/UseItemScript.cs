using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class UseItemScript : MonoBehaviour
{
    public enum Items
    {
        Watch,
        Syringe,
        Revolver,
        CrossedNails,
        None
    }

    [Header("Watch Values")]
    public static bool watchActive = false;
    [SerializeField] float watchMaxTime = 5;
    private float watchIncrement = 0;
    [Header("Syringe Values")]
    public static bool syringeActive = false;
    [SerializeField] public static float syringeSpeed = 1.3f;
    [SerializeField] public static float syringeDrain = 10f;
    [SerializeField] float syringeMaxTime = 10;
    private float syringeIncrement = 0;
    public static bool revolver = false;
    GameObject playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.Find("PlayerCapsule");
    }

    void Update()
    {
        if (watchActive == true)
        {
            watchIncrement += Time.deltaTime;
            
            if (watchIncrement >= watchMaxTime)
            {
                watchIncrement = 0;
                watchActive = false;
            }
        }

        if (syringeActive == true)
        {
            syringeIncrement += Time.deltaTime;
            if (syringeIncrement >= syringeMaxTime)
            {
                syringeIncrement = 0;
                syringeActive = false;
            }
        }

        if (playerObject.GetComponent<InventoryScript>().inventory[0] == UseItemScript.Items.Revolver || playerObject.GetComponent<InventoryScript>().inventory[1] == UseItemScript.Items.Revolver)
        {
            revolver = true;
        }
    }

    static public void UseItem(Items items)
    {
        switch (items)
        {
            case Items.Watch:
                watchActive = true;
                break;
            case Items.Syringe:
                syringeActive = true;
                break;
            case Items.Revolver:
                break;
            case Items.CrossedNails:
                //If player is by attack location then it will get which location
                //The players at and stop the timer
                break;
            default:
                break;
        }
    }
}
