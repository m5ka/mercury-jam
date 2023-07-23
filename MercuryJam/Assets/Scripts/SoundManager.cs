using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public float MusicVoume = 0.2f;
    public AudioSource BackgroundMusic;
    void Start()
    {
        BackgroundMusic.volume = MusicVoume;
        BackgroundMusic.Play();
    }
}
