using UnityEngine;
using UnityEngine.UI;
public class JournalLock : MonoBehaviour
{
    public GameObject Journal2;
    public GameObject Journal3;
    public GameObject Journal4;
    public GameObject Journal5;
    public GameObject Journal6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SettingsScript.GetDifficultyCompleted() == 4)
        {
            Journal2.GetComponent<Button>().interactable = true;
            Journal3.GetComponent<Button>().interactable = true;
            Journal4.GetComponent<Button>().interactable = true;
            Journal5.GetComponent<Button>().interactable = true;
            Journal6.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 3)
        {
            Journal2.GetComponent<Button>().interactable = true;
            Journal3.GetComponent<Button>().interactable = true;
            Journal4.GetComponent<Button>().interactable = true;
            Journal5.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 2)
        {
            Journal2.GetComponent<Button>().interactable = true;
            Journal3.GetComponent<Button>().interactable = true;
            Journal4.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 1)
        {
            Journal2.GetComponent<Button>().interactable = true;
            Journal3.GetComponent<Button>().interactable = true;
        }
        else if (SettingsScript.GetDifficultyCompleted() == 0)
        {
            Journal2.GetComponent<Button>().interactable = true;
        }
    }
}
