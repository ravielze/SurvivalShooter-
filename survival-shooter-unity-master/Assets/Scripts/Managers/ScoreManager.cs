using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public string gameMode = "Wave";

    private static float time = 0;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
        time = 0;
    }

    public static int TimeSurvived()
    {
        return (int)time;
    }

    void Update()
    {
        time += Time.deltaTime;
        string appended = "";
        if (gameMode == "Wave")
        {
            appended = "Wave: " + EnemyManager.Wave();
        }
        else
        {
            int rt = (int)time;
            int sec = rt % 60;
            int min = (rt / 60);
            if (min == 0)
            {
                appended = "Time Survived: " + $"{sec}s";
            }
            else
            {
                appended = "Time Survived: " + $"{min}m {sec}s";
            }
        }
        text.text = "Score: " + score + " - " + appended;
    }
}
