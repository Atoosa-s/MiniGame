using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLose : MonoBehaviour
{
    public CoinManager coinManager;
    public MainMenu mainMenu;


    void Start()
    {
        coinManager = CoinManager.instance;
    }

    
    public void boxHit()
    {
        Debug.Log("coin = minus ");
        coinManager.RemoveCoin(4);

        GameOver();

    }


    public void GameOver()
    {

        if (coinManager.getCoin() < 0)
        {
            Debug.Log("Game Over!");  // ← Panel anzeigen
            Time.timeScale = 0f;
            coinManager.RemoveCoin(3);
            SceneManager.LoadScene(2);
            

        }
    }


}