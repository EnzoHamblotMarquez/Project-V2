using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("AudioSource")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("AudioClips")]
    public AudioClip backgroundMusic;
    public AudioClip slash;
    public AudioClip damage;
    public AudioClip die;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        musicSource.clip = backgroundMusic;

    }

    private void Start()
    {
        sfxSource.volume = 1f;
        musicSource.volume = 1f;
    }

    public void PlaySFX(AudioClip audioClip, float volume)
    {
        sfxSource.pitch = Random.Range(0.8f, 1.2f);
        sfxSource.PlayOneShot(audioClip, volume);
    }
}
