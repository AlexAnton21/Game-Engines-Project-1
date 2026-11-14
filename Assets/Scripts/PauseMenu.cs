using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Referenzen")]
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        // Zur Sicherheit: Panel ausblenden, Zeit und Ton auf normal setzen
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    void Update()
    {
        // Optional: Pausieren auch per ESC-Taste erlauben
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Spielzeit anhalten
        AudioListener.pause = true; // Musik & Sounds pausieren
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Spielzeit läuft weiter
        AudioListener.pause = false; // Musik & Sounds laufen weiter
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // WICHTIG: Zeit wieder normalisieren, sonst ist das Menü eingefroren!
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }
}