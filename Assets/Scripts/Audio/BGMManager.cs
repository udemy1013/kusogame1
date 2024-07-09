using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }

    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private float volume = 1f;
    [SerializeField] private bool playOnAwake = true;

    private AudioSource audioSource;

    private void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudio();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudio()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.volume = volume;
        audioSource.loop = true;

        if (playOnAwake)
        {
            PlayBGM();
        }
    }

    public void PlayBGM()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void SetBGM(AudioClip newClip)
    {
        if (audioSource != null)
        {
            bool wasPlaying = audioSource.isPlaying;
            audioSource.clip = newClip;
            if (wasPlaying)
            {
                audioSource.Play();
            }
        }
    }
}