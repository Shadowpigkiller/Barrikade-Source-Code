using System;
using System.Threading;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class OverallCountDownTimer : MonoBehaviour
{
    private static bool tutorialTime = false;
    private static bool finishedTutorial = false;
    public TextMeshProUGUI winTimer;
    [SerializeField] float timer = 180f;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioClip stage1;
    [SerializeField] AudioClip stage2;
    [SerializeField] AudioClip stage3;
    [SerializeField] AudioClip tutorialMusic;
    private bool stage2Start = true;
    private bool stage3Start = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
            //backgroundMusic.Stop();
            //backgroundMusic.clip = stage1;
            //backgroundMusic.Play();
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
                if (!tutorialTime) {
                    gameObject.GetComponent<WinLoseScript>().ShowWinScreen(true);
                    if (SettingsScript.getDifficulty() == 1)
                    {
                        SettingsScript.SetDifficultyCompleted(1);
                    }
                    else if (SettingsScript.getDifficulty() == 2)
                    {
                        SettingsScript.SetDifficultyCompleted(2);
                    }
                    else if (SettingsScript.getDifficulty() == 3)
                    {
                        SettingsScript.SetDifficultyCompleted(3);
                    }
                    else if (SettingsScript.getDifficulty() == 4)
                    {
                        SettingsScript.SetDifficultyCompleted(4);
                    }
                    else{}
                }
                else
                {
                    finishedTutorial = true;
                    SetTimer(30f);
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
            if (!tutorialTime){
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

    public static void SetTutorialTime(bool value)
    {
        tutorialTime = value;
    }

    public static bool getTutorialFinished()
    {
        return finishedTutorial;
    }

    public void SetTimer(float value)
    {
        timer = value;
    }

    public static void SetTutorialFinsished(bool value)
    {
        finishedTutorial = value;
    }
}
