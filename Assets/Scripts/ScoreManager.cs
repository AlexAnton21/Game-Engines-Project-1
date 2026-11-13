using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Einstellungen")]
    public float scoreSpeed = 5f;

    [Header("Schwierigkeit")]
    public float globalSpeedMultiplier = 1f;
    private int nextMilestone = 50;

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

            if (currentScore >= nextMilestone)
            {
                globalSpeedMultiplier += 0.2f;
                nextMilestone += 50;
                Debug.Log("Neue Geschwindigkeit: " + globalSpeedMultiplier);
            }
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

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public int GetCurrentScore()
    {
        return Mathf.FloorToInt(currentScore);
    }

    public void ResetGame()
    {
        currentScore = 0f;
        isGameOver = false;
        globalSpeedMultiplier = 1f;
        nextMilestone = 50;
    }
}