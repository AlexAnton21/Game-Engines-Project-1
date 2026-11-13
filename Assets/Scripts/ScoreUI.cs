using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [Header("UI Text Anzeigen")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        if (highScoreText != null && ScoreManager.Instance != null)
        {
            highScoreText.text = "Best: " + ScoreManager.Instance.GetHighScore() + "m";
        }
    }

    void Update()
    {
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = ScoreManager.Instance.GetCurrentScore() + "m";
        }
    }
}
