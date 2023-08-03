using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public float DefaultMusicVolume = 0.2f;
    public float DefaultSoundVolume = 0.3f;

    public float musicVolume;
    public float soundVolume;

    public AudioSource BackgroundMusic;
    public AudioSource PlayerDeath;
    public AudioSource KillAllExplostion;

    public bool MusicMuted = false;
    public bool SoundMuted = false;
    void Start()
    {
        musicVolume = DefaultMusicVolume;
        soundVolume = DefaultSoundVolume;

        BackgroundMusic.volume = musicVolume;
        BackgroundMusic.Play();
    }

    public void UpdateBackgroundMusicVolume()
    {
        BackgroundMusic.volume = musicVolume;
    }

    public void PlayAbilitySound(AudioSource AbilitySound)
    {
        AbilitySound.volume = soundVolume;
        AbilitySound.Play();
    }

    public void PlayPlayerDeathSound()
    {
        PlayerDeath.volume = soundVolume;
        PlayerDeath.Play();
    }

    public void PlayKillAllExplostionSound()
    {
        KillAllExplostion.volume = soundVolume;
        KillAllExplostion.Play();
    }
}
