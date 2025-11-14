using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    //This Script is to manage all settings related functions. It must be attached to any toggle or slider UI element in the settings menu
    //Settings List enum is to determine which setting this particular instance of the script is managing
    public enum SettingsList
    {
        MusicVolume,
        SVXVolume,
        Difficulty
    }

    //Reference Variables
    public SettingsList setting;


    public static float musicVolume;
    public static float SVXVolume;

    //Functions
    private void Start()
    {

        //Issue where volume immediatetly sets to 0 on start, so set default values here
        musicVolume = 1f;
        SVXVolume = 1f;

    }

    public void OnToggleValueChanged(bool isOn) //Toggle Change Handler
    {
        
    }

    public void OnSliderValueChanged(float value) //Slider Change Handler
    {
        switch (setting)
        {
            case SettingsList.MusicVolume:
                musicVolume = value;
                Debug.Log("Music Volume set to: " + musicVolume);
                break;
            case SettingsList.SVXVolume:
                SVXVolume = value;
                break;
        }
    }
}
