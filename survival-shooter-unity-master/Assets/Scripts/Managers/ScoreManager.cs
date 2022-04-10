using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public string gameMode = "Wave";
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        string appended = "";
        if (gameMode == "Wave")
        {
            appended = "Wave: " + EnemyManager.Wave();
        }
        text.text = "Score: " + score + " - " + appended;
    }
}
