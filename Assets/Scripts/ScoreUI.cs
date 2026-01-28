using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += OnScoreChange;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= OnScoreChange;
    }

    private void OnScoreChange(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
