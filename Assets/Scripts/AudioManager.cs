using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameoverSound;
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private AudioClip flyingSound;
    private AudioSource backgroundMusic;
    private AudioSource sourceEffect;

    private bool isPlayerDeath = false;

    private void Awake()
    {
        backgroundMusic = transform.Find("BackgroundMusic").GetComponent<AudioSource>();
        sourceEffect = transform.Find("SoundsEffect").GetComponent<AudioSource>();
    }

    public void OnStartGame()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
        backgroundMusic.volume = 0.3f;
        backgroundMusic.pitch = 1;
    }

    public void OnGameOver()
    {
        if (!isPlayerDeath)
        {
            sourceEffect.PlayOneShot(gameoverSound);
            isPlayerDeath = true;
        }

        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.volume = 0;
            backgroundMusic.pitch = 0; ;
        }
    }

    public void OnPointEarned()
    {
        sourceEffect.PlayOneShot(pointSound);
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
            backgroundMusic.volume = 0.1f;
            backgroundMusic.pitch = 0.3f;
        }
    }

    public void OnPlayerTapToFly()
    {
        sourceEffect.PlayOneShot(flyingSound);
        sourceEffect.volume = 0.2f;
    }
}
