using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.pitch = Random.Range(0.1f, 1.2f);
        sfxSource.PlayOneShot(audioClip);
    }
}
