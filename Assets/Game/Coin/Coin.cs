using UnityEngine;

public class Coin : MonoBehaviour
{


    public int coinValue = 1;
    public AudioManager audioManager;
     
     private void Start()
{
    if (audioManager == null)
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            audioManager.mCoin(audioManager.Coin);
            CoinManager.instance.AddCoin(coinValue);
            Destroy(gameObject);

        }
        
    }
}
