using UnityEngine;

public class AttackAreaMusic : MonoBehaviour
{
    public static AttackAreaMusic instance;
    [SerializeField] private AudioSource sfxPlayer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayMusic(AudioClip music, Transform spawnTransform, float volume, bool active)
    {
        //Spawn GameObject
        AudioSource audioSource = Instantiate(sfxPlayer, spawnTransform.position, Quaternion.identity);

        //Assign Audio Clip
        audioSource.clip = music;

        //Assign Volume
        audioSource.volume = volume;

        //Play Music
        audioSource.Play();

        //get length of song
        //float clipLength = audioSource.clip.length;

        //check if audio source exists and if the attack location is active
        if (audioSource && active == false)
        {
            Destroy(audioSource.gameObject);
        }
    }
}
