using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Quelle & Clips")]
    public AudioSource audioSource;
    public AudioSource jetpackSource;
    public AudioClip musicClip;
    public AudioClip jumpClip;

    void Start()
    {
        PlayMusic();

        if (jetpackSource != null && jumpClip != null)
        {
            jetpackSource.clip = jumpClip;
            jetpackSource.loop = true;
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null && musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StartJetpack()
    {
        if (jetpackSource != null && !jetpackSource.isPlaying)
        {
            jetpackSource.Play();
        }
    }

    public void StopJetpack()
    {
        if (jetpackSource != null && jetpackSource.isPlaying)
        {
            jetpackSource.Stop();
        }
    }
}