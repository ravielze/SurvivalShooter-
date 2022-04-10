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
/*       var json = PlayerPrefs.GetString("scores", "{}");
       scoreData = JsonUtility.FromJson<ScoreData>(json);*/
        scoreData = new ScoreData();
    }

    public IEnumerable<Score> GetScores()
    {
        return scoreData.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        scoreData.scores.Add(score);
    }

/*    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("scores", json);

    }*/
}
