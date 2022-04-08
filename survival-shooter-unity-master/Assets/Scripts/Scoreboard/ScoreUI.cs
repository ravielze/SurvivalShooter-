using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreboardManager scoreboardManager;

    void Start()
    {
        scoreboardManager.AddScore(new ScoreUI("Akeyla", 8));
        scoreboardManager.AddScore(new ScoreUI("Alfan", 9));
        scoreboardManager.AddScore(new ScoreUI("Viel", 10));

        var scores = scoreboardManager.GetScores().ToArray();
        for(int i = 0; i < scores.length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
