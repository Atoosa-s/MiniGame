using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


  public TMP_Text highScore;
  public static bool GameIsPaused = false;
  public GameObject pauseMenuUI;
  public Toggle audioToggle;



  void Start()
  {
    
    int savedHigh = PlayerPrefs.GetInt("HighScore", 0);


    highScore.text = "High Score: " + savedHigh;

    if (audioToggle != null && AudioManager.instance != null)
    {
      audioToggle.isOn = !AudioManager.instance.IsMuted();
    }

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

  public void OnAudioToggleChanged(bool isOn)
  {
    if (AudioManager.instance != null)
    {
      if (isOn)
      {
        AudioManager.instance.TurnMusicOn();
      }
      else
      {
        AudioManager.instance.SetMute();
      }
    }
  }

  public void OnMusicOnButton()
  {
    if (AudioManager.instance != null)
    {
      AudioManager.instance.TurnMusicOn();
      if (audioToggle != null)
      {
        audioToggle.isOn = true;
      }
    }
  }
}
