using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("UI Text Anzeigen")]
    public TextMeshProUGUI scoreText;      // Groe Zahl: Aktuelle Meter
    public TextMeshProUGUI highScoreText;  // Kleine Zahl: Bester Highscore

    [Header("Einstellungen")]
    public float scoreSpeed = 5f;          // Wie schnell die Meter steigen

    private float currentScore = 0f;
    private int highScore = 0;
    private bool isGameOver = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        // 1. Gespeicherten Highscore laden (Standard ist 0, falls noch keiner existiert)
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // 2. Highscore-Text direkt beim Start anzeigen
        if (highScoreText != null)
        {
            highScoreText.text = "Best: " + highScore + "m";
        }
    }

    void Update()
    {
        // Solange wir leben, zhlen die Meter hoch
        if (!isGameOver)
        {
            currentScore += scoreSpeed * Time.deltaTime;

            if (scoreText != null)
            {
                scoreText.text = Mathf.FloorToInt(currentScore) + "m";
            }
        }
    }

    // Wird aufgerufen, wenn der Spieler stirbt
    public void GameOver()
    {
        isGameOver = true;
        int finalScore = Mathf.FloorToInt(currentScore);

        // Prfen, ob der aktuelle Lauf besser war als der alte Rekord
        if (finalScore > highScore)
        {
            highScore = finalScore;

            // Dauerhaft auf der Festplatte speichern
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if (highScoreText != null)
            {
                highScoreText.text = "Best: " + highScore + "m";
            }
        }
    }

    public int GetHighScore()
    {
      return  PlayerPrefs.GetInt("HighScore", 0);
    }
    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1 && scoreText != null && highScoreText != null)
        {
            Canvas currentCanvas = FindAnyObjectByType<Canvas>();
            scoreText = Instantiate(scoreText, currentCanvas.transform);
            highScoreText = Instantiate(highScoreText, currentCanvas.transform);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
