using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("-----Audio Source----")]
    [SerializeField] private AudioSource MusicSource;

    [Header("-----Audio Clipp----")]
    public AudioClip backGround;
    public AudioClip Coin;
    public AudioClip BoxTouch;
    public AudioClip CheckPoint;

    private const string AudioMutedKey = "AudioMuted";
    private bool isMuted;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (MusicSource == null)
        {
            MusicSource = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt(AudioMutedKey, 0) == 1;
        ApplyMuteState();
        EnsureBackgroundPlaying();
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    private void SetMutedState(bool muted)
    {
        isMuted = muted;
        PlayerPrefs.SetInt(AudioMutedKey, muted ? 1 : 0);
        PlayerPrefs.Save();
        ApplyMuteState();

        if (!muted)
        {
            EnsureBackgroundPlaying();
        }
    }

    public void SetMute()
    {
        SetMutedState(true);
    }

    private void ApplyMuteState()
    {
        if (MusicSource != null)
        {
            MusicSource.mute = isMuted;
        }

        AudioListener.volume = isMuted ? 0f : 1f;
    }

    public void PlaySfx(AudioClip clip)
    {
        if (MusicSource == null || clip == null || isMuted)
        {
            return;
        }

        MusicSource.PlayOneShot(clip);
    }

    public void mCoin(AudioClip clip)
    {
        PlaySfx(clip);
    }

    public void PlayBox(AudioClip clip)
    {
        PlaySfx(clip);
    }

    public void stop()
    {
        if (MusicSource != null)
        {
            MusicSource.Pause();
        }

        SetMute();
    }

    public void TurnMusicOn()
    {
        SetMutedState(false);
        EnsureBackgroundPlaying();
    }

    private void EnsureBackgroundPlaying()
    {
        if (MusicSource == null || backGround == null || isMuted)
        {
            return;
        }

        if (MusicSource.clip != backGround)
        {
            MusicSource.clip = backGround;
        }

        if (!MusicSource.isPlaying)
        {
            MusicSource.Play();
        }
    }
}
