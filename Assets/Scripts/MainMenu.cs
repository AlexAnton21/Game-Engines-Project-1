using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        // Gespeicherten Highscore laden und im Men anzeigen
        if (ScoreManager.Instance != null)
        {
            highScoreText.text = "Highscore: " + ScoreManager.Instance.GetHighScore() + "m";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Spiel beendet!");
        Application.Quit();
    }
}

