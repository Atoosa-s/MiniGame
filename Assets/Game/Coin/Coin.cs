using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    private AudioManager audioManager;

    private void Awake()
    {
        CacheAudioManager();
    }

    private void CacheAudioManager()
    {
        if (AudioManager.instance != null)
        {
            audioManager = AudioManager.instance;
        }
        else
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (audioManager == null)
        {
            CacheAudioManager();
        }

        if (audioManager != null)
        {
            audioManager.mCoin(audioManager.Coin);
        }

        CoinManager.instance.AddCoin(coinValue);
        Destroy(gameObject);
    }
}
