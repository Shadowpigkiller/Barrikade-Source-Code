using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class OverallCountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI winTimer;
    private float timer = 180f;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioClip stage1;
    [SerializeField] AudioClip stage2;
    [SerializeField] AudioClip stage3;
    private bool stage2Start = true;
    private bool stage3Start = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        backgroundMusic.Stop();
        backgroundMusic.clip = stage1;
        backgroundMusic.Play();

    }
    // Update is called once per frame
    void Update()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        winTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer <= 0)
        {
            winTimer.text = string.Format("{0:00}:{1:00}", 0, 0);
            gameObject.GetComponent<WinLoseScript>().ShowWinScreen(true);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (stage3Start && timer <= 60)
        {
            stage3Start = false;
            backgroundMusic.Stop();
            backgroundMusic.clip = stage3;
            backgroundMusic.Play();
        }
        else if (stage2Start && timer <= 120)
        {
            stage2Start = false;
            backgroundMusic.Stop();
            backgroundMusic.clip = stage2;
            backgroundMusic.Play();
        }
    }
}
