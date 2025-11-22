using System.Runtime.ExceptionServices;
using StarterAssets;
using UnityEngine;

public class OpenTimerPopUp : MonoBehaviour
{
    [SerializeField] public GameObject TimerWinPopUpObject;
    [SerializeField] public GameObject TutorialBackground;
    private void OnTriggerEnter(Collider other)
    {
        TimerWinPopUpObject.SetActive(true);
        TutorialBackground.SetActive(true);
        PlayerReference.Instance.Player.GetComponent<FirstPersonController>().FreezePlayer();
    }
}
