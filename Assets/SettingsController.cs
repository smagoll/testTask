using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private GameObject volume;
    [SerializeField]
    private GameObject sfx;
    [SerializeField]
    private AudioManager audioManager;

    public void ChangeVolume()
    {
        audioManager.musicSource.enabled = !audioManager.musicSource.enabled;
    }

    public void ChangeSFX()
    {
        audioManager.sfxSource.enabled = !audioManager.sfxSource.enabled;
    }
}
