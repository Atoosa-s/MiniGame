using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    private int totalCoins = 0;
    private int savedHighScore = 0;

    public TMP_Text scoreText;
    public TMP_Text highScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
        savedHighScore = PlayerPrefs.GetInt("HighScore", 0);

       
        scoreText.text = totalCoins + " Points!";
        highScore.text = "HighScore " + savedHighScore;
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount;
        scoreText.text = totalCoins + " Points!";

       
        if (totalCoins > savedHighScore)
        {
            savedHighScore = totalCoins;
            PlayerPrefs.SetInt("HighScore", savedHighScore);

         
            highScore.text = "HighScore " + savedHighScore;
        }

        Debug.Log("Coins: " + totalCoins);
    }
    public int getHighCoin()
    {
        return savedHighScore;
        
    }

    public void RemoveCoin(int amount)
    {
        totalCoins -= amount;
        scoreText.text = totalCoins + " Points!";
    }

    public int getCoin()
    {
        return totalCoins;
    }
}