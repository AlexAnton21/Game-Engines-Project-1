using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Steuerung")]
    public float schubKraft = 15f;

    [Header("Sterben & Game Over")]
    public Sprite deadSprite;
    public GameObject gameOverUI;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetGame();
        }
    }

    void Update()
    {
        // Wenn tot: Steuerung blockiert, Neustart mit R
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }

        // Schub nach oben
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * schubKraft);
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        // 1. Sprite ndern
        if (deadSprite != null && sr != null)
        {
            sr.sprite = deadSprite;
        }

        // 2. Um 45 Grad drehen, damit er liegt
        transform.rotation = Quaternion.Euler(0, 0, -45f);

        // 3. Spawner anhalten
        ObstacleSpawner spawner = Object.FindAnyObjectByType<ObstacleSpawner>();
        if (spawner != null)
        {
            spawner.isSpawning = false;
        }

        // 4. ScoreManager anhalten & Highscore prfen
        ScoreManager scoreManager = Object.FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.GameOver();
        }

        // 5. Game Over Text fett in Rot anzeigen
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Debug.LogWarning("[Game Over] Der Spieler ist gestorben! Drcke R fr Neustart.");
    }
}
