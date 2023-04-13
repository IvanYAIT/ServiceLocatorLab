using UnityEngine;

public class PlayerPrefsSaver : ISaver
{
    private const string SCORE = "Score";

    public void SaveScore(int score, string path = null)
    {
        PlayerPrefs.SetInt(SCORE, score);
    }
}