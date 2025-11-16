using UnityEngine;

public class AudioFollower : MonoBehaviour
{
    //If there are several audio sources attached to an object, attach this script to it.
    //This script will make the AudioSource that isnt immediately called follow the same volume as the main AudioSource 

    public AudioSource mainAudioSource;
    public AudioSource followerAudioSource;

    private void Update()
    {
        followerAudioSource.volume = mainAudioSource.volume;
    }
}
