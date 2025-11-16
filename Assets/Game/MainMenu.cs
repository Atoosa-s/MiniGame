using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor;

public class MainMenu : MonoBehaviour
{


  public TMP_Text highScore;
  public static bool GameIsPaused = false;
  public GameObject pauseMenuUI;



  void Start()
  {
    // Highscore laden
    int savedHigh = PlayerPrefs.GetInt("HighScore", 0);

    // Text setzen
    highScore.text = "High Score: " + savedHigh;

  }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
              Resume();
            }
            else
            {
              Pause();
            }
        }
    }
    public void PlayGamen()
  {
    Time.timeScale = 1f;
    SceneManager.LoadScene(1);
    
    

  }

  public void QuitGame()
  {

    Application.Quit();

  }
  public void Menu()
  {
    SceneManager.LoadScene(0);
  }

  public void Resume()
    {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }
    public void Pause()
    {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }
}
