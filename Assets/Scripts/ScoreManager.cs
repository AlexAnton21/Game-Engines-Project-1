using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Einstellungen")]
    public float scoreSpeed = 5f;

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
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (!isGameOver)
        {
            currentScore += scoreSpeed * Time.deltaTime;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        int finalScore = Mathf.FloorToInt(currentScore);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    // Diese zwei Methoden nutzt unser neues UI-Skript, um die Zahlen abzufragen:
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public int GetCurrentScore()
    {
        return Mathf.FloorToInt(currentScore);
    }
}