using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject attackLocationsParent;
    [SerializeField] private float attackInitiatorTimer;
    [SerializeField] private float maxAttackInitiatorTimer;
    [HideInInspector] private int attackLocations;

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
        GameObject chosenArea = attackLocationsParent.transform.GetChild(chosenAreaNum).gameObject;
        chosenArea.GetComponent<AttackLocation>().ActivateAttack();
    }
}
