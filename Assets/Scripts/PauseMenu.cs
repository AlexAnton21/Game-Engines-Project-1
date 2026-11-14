using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Referenzen")]
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        //Panel ausblenden, Zeit und Ton auf normal setzen
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    void Update()
    {
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
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; //Zeit wieder normalisieren
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }
}