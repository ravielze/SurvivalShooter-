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
        scoreboardManager.AddScore(new Score("Akeyla", 8));
        scoreboardManager.AddScore(new Score("Alfan", 9));
        scoreboardManager.AddScore(new Score("Viel", 10));

        var scores = scoreboardManager.GetScores().ToArray();
        for(int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
