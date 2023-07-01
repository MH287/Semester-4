using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : ManagerModule
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;

    //TEST
    private void Start()
    {
        PlayMusic(_musicSource.clip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        _musicSource.PlayOneShot(musicClip);
    }

    public void PlayEffect(AudioClip effectClip)
    {
        _effectSource.PlayOneShot(effectClip);
    }

    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}