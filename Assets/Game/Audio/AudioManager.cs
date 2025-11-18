using UnityEngine;

public class AudioManager : MonoBehaviour
{
     public static AudioManager instance;
    [Header("-----Audio Source----")]
    [SerializeField] AudioSource MusicSource;

    [Header("-----Audio Clipp----")]
    public AudioClip backGround;
    public AudioClip Coin;
    public AudioClip BoxTouch;
    public AudioClip CheckPoint;

    void Awake()
    {
        // Singleton erstellen
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void Start()
    {
        MusicSource.clip = backGround;
        MusicSource.Play();

    }

    public void mCoin(AudioClip clip)
    {
        MusicSource.PlayOneShot(clip);

    }

    public void stop()
    {
        MusicSource.Pause();
    }
    




}
