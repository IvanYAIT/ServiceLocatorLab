using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button collectBtn;
    [SerializeField] public int scorePerClick;

    public int GetScorePerClick() => scorePerClick;
    public void ChangeScore(int score) =>
        scoreText.text = $"{score}";

    public void AddListener(UnityAction action) =>
        collectBtn.onClick.AddListener(action);

    public void RemoveListener(UnityAction action) =>
        collectBtn.onClick.RemoveListener(action);
}
