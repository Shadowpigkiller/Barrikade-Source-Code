using System;
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
    [SerializeField] float syringeSpeedNonStatic = 1.3f;
    public static float syringSpeed;
    [SerializeField] float syringeDrainNonStatic = 10f;
     public static float syringDrain;
    [SerializeField] float syringeMaxTime = 10;
    private float syringeIncrement = 0;
    public static bool revolver = false;
    [SerializeField] public AudioClip revolverSFX;
    public static AudioClip revolverSFXstatic;
    [Header("Crossed Nails values")]
    public static bool crossedNails = false;
    public static bool crossPressed = false;
    public static bool crossNailsSelected = false;
    public static int[] windowBlocked = {-1, -1, -1, -1, -1, -1, -1};
    [SerializeField] float crossBlockedMax = 15f;
    public static float crossBlockMaxStatic;
    //private float crossBlockIncrement = 0;
    GameObject playerObject;
    [SerializeField] GameObject attackParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.Find("PlayerCapsule");
        revolverSFXstatic = revolverSFX;
        syringDrain = syringeDrainNonStatic;
        syringSpeed = syringeSpeedNonStatic;
        crossBlockMaxStatic = crossBlockedMax;
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
        } else
        {
            revolver = false;
        }

        //Debug.Log(crossedNails);
        if (crossNailsSelected)
        {
            crossNailsSelected = false;
            crossedNails = true;
        } else
        {
            crossedNails = false;
        }

        if (Array.Exists(windowBlocked, window => window != -1))
        {
            for(int i = 0; i < windowBlocked.Length; i++)
            {
                if(windowBlocked[i] > -1)
                {
                    attackParent.transform.GetChild(windowBlocked[i]).gameObject.GetComponent<AttackLocation>().WindowCrossNailed(i);
                }
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
                break;
            default:
                break;
        }
    }
}

