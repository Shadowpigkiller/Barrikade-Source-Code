using UnityEngine;

public class AttackAreaMusic : MonoBehaviour
{
    public static AttackAreaMusic instance;
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource sfxPlayer;
    [HideInInspector] private AudioSource[] audioSources;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSources = new AudioSource[GameObject.Find("AttackAreas").transform.childCount];
    }

    public void PlayMusic(AudioClip music, Transform spawnTransform, float volume, bool active, int location)
    {
        //check if audio source exists and if the attack location is active
        if (active == false)
        {
            Destroy(audioSources[location].gameObject);
        }
        else
        {
            //Spawn GameObject
            audioSources[location] = Instantiate(musicPlayer, spawnTransform.position, Quaternion.identity);

            //Assign Audio Clip
            audioSources[location].clip = music;

            //Assign Volume
            audioSources[location].volume = volume;

            //Play Music
            audioSources[location].Play();
        }
    }

    public void PlaySFX(AudioClip sfx, Transform spawnTransform, float volume)
    {
        //Spawn GameObject
        AudioSource sfxSource = Instantiate(sfxPlayer, spawnTransform.position, Quaternion.identity);

        //Assign Audio Clip
        sfxSource.clip = sfx;

        //Assign Volume
        sfxSource.volume = volume;

        //Play Music
        sfxSource.Play();

        //get length of song
        float clipLength = sfxSource.clip.length;

        //check if audio source exists and if the attack location is active
        Destroy(sfxSource.gameObject, clipLength); 
    }
}


