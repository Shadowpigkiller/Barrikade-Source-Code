using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject attackLocationsParent;
    [SerializeField] private float attackInitiatorTimer;
    [SerializeField] private float maxAttackInitiatorTimer;
    [HideInInspector] private int attackLocations;
    [HideInInspector] private int noRepeat;
    [SerializeField] public static AudioClip revolverSFX;

    void Start()
    {
        attackInitiatorTimer = maxAttackInitiatorTimer;
        attackLocations = attackLocationsParent.transform.childCount;
    }

    private void Update()
    {
        if (UpdateInitiatorTimer() <= 0)
        {
            InitiateAttack();
            attackInitiatorTimer = maxAttackInitiatorTimer;
        }
    }

    //How long it will take until the an area is activated again
    private float UpdateInitiatorTimer()
    {
        attackInitiatorTimer -= Time.deltaTime;
        return attackInitiatorTimer;
    }

    private void InitiateAttack()
    {
        int chosenAreaNum = Random.Range(0, attackLocations);
        while (chosenAreaNum == noRepeat || chosenAreaNum == UseItemScript.windowBlocked)
        {
            chosenAreaNum = Random.Range(0, attackLocations);
        }
        noRepeat = chosenAreaNum;
        GameObject chosenArea = attackLocationsParent.transform.GetChild(chosenAreaNum).gameObject;
        //if the area is not active then activate it else do not activate it
        if (!chosenArea.GetComponent<AttackLocation>().attackActive)
        {
            chosenArea.GetComponent<AttackLocation>().ActivateAttack();
        }
    }

    public void DeactivateCrossedOutlines(int location)
    {
        GameObject chosenArea = attackLocationsParent.transform.GetChild(location).gameObject;
        chosenArea.GetComponent<AttackLocation>().CrossedNailOutline(false);
    }
}
