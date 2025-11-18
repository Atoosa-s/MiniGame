using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source----")]
    [SerializeField] AudioSource MusicSource;

    [Header("-----Audio Clipp----")]
    public AudioClip backGround;
    public AudioClip Coin;
    public AudioClip BoxTouch;
    public AudioClip CheckPoint;

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
