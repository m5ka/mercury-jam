using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public float DefaultMusicVolume = 0.0f;
    public float DefaultSoundVolume = 0.3f;

    public float musicVolume;
    public float soundVolume;

    public AudioSource BackgroundMusic;
    public AudioSource PlayerDeath;
    public AudioSource KillAllExplostion;
    public AudioSource SkeletonDeath;
    public AudioSource SkeletonDamage;
    public AudioSource PlayerDamage;
    public AudioSource BatDeath;
    public AudioSource BatDamage;

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

    public void PlaySkeletonDeath()
    {
        SkeletonDeath.volume = soundVolume;
        SkeletonDeath.Play();
    }

    public void PlaySkeletonDamage()
    {
        SkeletonDamage.volume = soundVolume;
        SkeletonDamage.Play();
    }

    public void PlayPlayerDamage()
    {
        PlayerDamage.volume = soundVolume;
        PlayerDamage.Play();
    }

    public void PlayBatDeath()
    {
        BatDeath.volume = soundVolume;
        BatDeath.Play();
    }

    public void PlayBatDamage()
    {
        BatDamage.volume = soundVolume;
        BatDamage.Play();
    }
}
