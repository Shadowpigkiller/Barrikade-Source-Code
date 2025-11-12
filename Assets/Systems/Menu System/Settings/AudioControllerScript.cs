using UnityEngine;

public class AudioControllerScript : MonoBehaviour
{
    //This Controller Script is to manage all audio related settings and functions. It must be attached to an audio source object
    //For any Music or SFX related sources

    AudioSource audioSource;

    public enum AudioType
    {
        Music,
        SFX
    }
    public AudioType audioType;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        switch (audioType)
        {
            case AudioType.Music:
                audioSource.volume = SettingsScript.musicVolume;
                break;
            case AudioType.SFX:
                audioSource.volume = SettingsScript.SVXVolume;
                break;
        }

    }
}
