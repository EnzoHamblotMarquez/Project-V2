using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField] 
    private Slider masterVolume;
    [SerializeField]
    private Slider SFXVolume;
    [SerializeField]
    private Slider musicVolume;


    public void Start()
    {
        ChangeMasterVolume();
        ChangeMusicVolume();
        ChangeSFXVolume();
    }

    public void ChangeMasterVolume()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume.value) * 20);
    }

    public void ChangeSFXVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXVolume.value) * 20);
    }

    public void ChangeMusicVolume()
    {
        audioMixer.SetFloat("Music", Mathf.Log10(musicVolume.value) * 20);
    }
}
