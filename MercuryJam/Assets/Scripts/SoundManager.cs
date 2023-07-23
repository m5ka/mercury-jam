using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public float MusicVolume = 0.2f;
    public float SoundVolume = 0.3f;

    public AudioSource BackgroundMusic;
    public AudioSource Fireball;
    void Start()
    {
        BackgroundMusic.volume = MusicVolume;
        BackgroundMusic.Play();
    }

    public void PlayFireball()
    {
        Fireball.volume = SoundVolume;
        Fireball.Play();
    }
}
