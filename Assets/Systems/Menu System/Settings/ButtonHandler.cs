using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject EasyButton;
    public GameObject MediumButton;
    public GameObject HardButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SettingsScript.getDifficulty() == 1)
        {
            EasyButton.GetComponent<Button>().interactable = false;
        }
        else if (SettingsScript.getDifficulty() == 2)
        {
            MediumButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            HardButton.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
