using System.IO;
using UnityEngine;

public class JSONSaver : ISaver
{
    public void SaveScore(int score, string path = null)
    {
        if (!File.Exists(path))
        {
            var fs = new FileStream(path, FileMode.Create);
            fs.Dispose();
        }


        string scoreToJson = JsonUtility.ToJson(new ScoreData(score));
        File.WriteAllText(path, scoreToJson);
    }
}

public class ScoreData
{
    public int Score;

    public ScoreData(int score)
    {
        Score = score;
    }
}