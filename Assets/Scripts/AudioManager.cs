using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip touchButton;

    private void Awake()
    {
        GlobalEventManager.PlaySFXButton.AddListener(PlaySFXButton);
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
    public void PlaySFXButton()
    {
        sfxSource.PlayOneShot(touchButton);
    }
}
