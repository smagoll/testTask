using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "sfx")]
public class SFX : ScriptableObject
{
    public AudioSource sfxSource;
    public AudioClip clip;

    public void PlayClip()
    {
        sfxSource.PlayOneShot(clip);
    }
}
