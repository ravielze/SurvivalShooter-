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
       var json = PlayerPrefs.GetString("scores", "{}");
       scoreData = JsonUtility.FromJson<ScoreData>(json);

    }

    public IEnumerable<Score> GetScores()
    {
        return scoreData.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        scoreData.scores.Add(score);
    }

   private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(scoreData);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);

    }
}
