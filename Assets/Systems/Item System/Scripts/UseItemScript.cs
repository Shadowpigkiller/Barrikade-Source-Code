using System.ComponentModel;
using Unity.VisualScripting;
//using UnityEditor.ShaderKeywordFilter;
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
    [Header("Crossed Nails values")]
    public static bool crossedNails = false;
    public static bool crossPressed = false;
    public static bool crossNailsSelected = false;
    public static int windowBlocked = -1;
    [SerializeField] float crossBlockedMax = 15;
    private float crossBlockIncrement = 0;
    GameObject playerObject;
    [SerializeField] public AttackLocation attackLocationScript;

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

        if (crossNailsSelected)
        {
            crossNailsSelected = false;
            crossedNails = true;
        }

        if (windowBlocked > -1)
        {
            Debug.Log(crossBlockIncrement);
            crossBlockIncrement += Time.deltaTime;
            if (crossBlockIncrement >= crossBlockedMax)
            {
                attackLocationScript.CrossedNailOutline(false, windowBlocked);
                crossBlockIncrement = 0;
                windowBlocked = -1;
            }
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
                //crossNailsSelected = true;
                break;
            default:
                break;
        }
    }
}
