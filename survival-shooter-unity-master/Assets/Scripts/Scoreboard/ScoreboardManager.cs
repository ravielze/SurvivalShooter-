using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreboardManager : MonoBehaviour
{
    private ScoreData scoreData;

    void Awake()
    {
        scoreData = new ScoreData();
    }

    public IEnumerable<Score> GetScores()
    {
        return scoreData.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        scoreData.Add(score);
    }
}
