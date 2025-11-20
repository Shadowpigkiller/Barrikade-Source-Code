//using UnityEditor.SettingsManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject EasyButton;
    public GameObject EasyButton2;
    public GameObject EasyDescription;
    public GameObject MediumButton;
    public GameObject MediumButton2;
    public GameObject MediumDescription;
    public GameObject HardButton;
    public GameObject HardButton2;
    public GameObject HardDescription;
    public GameObject NIGHTMAREButton;
    public GameObject NIGHTMAREButton2;
    public GameObject NIGHTMAREDescription;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SettingsScript.getDifficulty() == 1)
        {
            EasyButton.GetComponent<Button>().interactable = false;
            EasyButton2.GetComponent<Button>().interactable = false;
            EasyDescription.SetActive(true);
        }
        else if (SettingsScript.getDifficulty() == 2)
        {
            MediumButton.GetComponent<Button>().interactable = false;
            MediumButton2.GetComponent<Button>().interactable = false;
            MediumDescription.SetActive(true);
        }
        else if (SettingsScript.getDifficulty() == 3)
        {
            HardButton.GetComponent<Button>().interactable = false;
            HardButton2.GetComponent<Button>().interactable = false;
            HardDescription.SetActive(true);
        }
        else
        {
            NIGHTMAREButton.GetComponent<Button>().interactable = false;
            NIGHTMAREButton2.GetComponent<Button>().interactable = false;
            NIGHTMAREDescription.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
