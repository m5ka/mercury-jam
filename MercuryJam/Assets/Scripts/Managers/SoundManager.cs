using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public float MusicVolume = 0.2f;
    public float SoundVolume = 0.3f;

    public AudioSource BackgroundMusic;
    void Start()
    {
        BackgroundMusic.volume = MusicVolume;
        BackgroundMusic.Play();
    }

    public void PlayAbilitySound(AudioSource AbilitySound)
    {
        AbilitySound.volume = SoundVolume;
        AbilitySound.Play();
    }
}
