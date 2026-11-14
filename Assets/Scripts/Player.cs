using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    [Header("Steuerung")]
    public float schubKraft = 5f;
    public AudioManager audioManager;
    public ParticleSystem jetpackParticles;


    [Header("Sterben & Game Over")]
    public Sprite deadSprite;
    public GameObject gameOverUI;
    public Volume globalVolume;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vignette vignette;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        if (globalVolume != null && globalVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.overrideState = true;
            vignette.intensity.value = 0f;
        }
    }

    void Update()
    {
        // Steuerung blocken
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }

        // Partikel und Sound sobald die Leertaste genutzt wird
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * schubKraft);
            if (audioManager != null) audioManager.StartJetpack();
            if (jetpackParticles != null && !jetpackParticles.isEmitting) jetpackParticles.Play();
        }
        else
        {
            if (audioManager != null) audioManager.StopJetpack();
            if (jetpackParticles != null && jetpackParticles.isEmitting) jetpackParticles.Stop();
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        if (vignette != null)
        {
            vignette.intensity.value = 0.55f;
        }

        if (audioManager != null) audioManager.StopJetpack();
        if (jetpackParticles != null) jetpackParticles.Stop();

        if (deadSprite != null && sr != null)
        {
            sr.sprite = deadSprite;
        }

        //Beim Tod wird das Player sprite um 45% gedreht
        transform.rotation = Quaternion.Euler(0, 0, -45f);

        //Spawner stopp
        ObstacleSpawner spawner = Object.FindAnyObjectByType<ObstacleSpawner>();
        if (spawner != null)
        {
            spawner.isSpawning = false;
        }

        //Scoremanager Stoppen
        ScoreManager scoreManager = Object.FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.GameOver();
        }

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Debug.LogWarning("[Game Over] Der Spieler ist gestorben! Drücke R für Neustart.");
    }
}