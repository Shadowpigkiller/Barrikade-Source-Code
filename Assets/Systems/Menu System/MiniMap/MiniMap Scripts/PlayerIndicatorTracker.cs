using Unity.VisualScripting;
using UnityEngine;

public class PlayerIndicatorTracker : MonoBehaviour
{
    [SerializeField] GameObject playerIndicator;
    public void OnTriggerEnter(Collider other)
    {
        playerIndicator.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        playerIndicator.SetActive(false);
        Debug.Log("Left");
    }
}
