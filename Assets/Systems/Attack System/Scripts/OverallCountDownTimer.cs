using System;
using TMPro;
using UnityEngine;

public class OverallCountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI winTimer;
    private float timer = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
    }
}
