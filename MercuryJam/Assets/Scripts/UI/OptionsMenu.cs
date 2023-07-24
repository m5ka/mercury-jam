using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[HideMonoScript]
public class OptionsMenu : MonoBehaviour
{
    [BoxGroup("Buttons"), LabelText("Back")] public Button backButton;
    [BoxGroup("Buttons"), LabelText("Mute Music")] public Button muteMusic;
    [BoxGroup("Buttons"), LabelText("Mute Sounds")] public Button muteSound;
    [BoxGroup("Labels"), LabelText("Mute Music")] public TMP_Text musicText;
    [BoxGroup("Labels"), LabelText("Mute Sounds")] public TMP_Text soundText;

    private void Start()
    {
        backButton.onClick.AddListener(BackButtonTaskOnClick);
        muteMusic.onClick.AddListener(MuteMusicButtonTaskOnClick);
        muteSound.onClick.AddListener(MuteSoundButtonTaskOnClick);
    }

    private void BackButtonTaskOnClick()
    {
        HUDManager.Instance.OpenPauseMenu();
        HUDManager.Instance.CloseOptionsMenu();
    }

    private void MuteMusicButtonTaskOnClick()
    {
        if (SoundManager.Instance.MusicMuted == false)
        {
            SoundManager.Instance.musicVolume = 0;
            SoundManager.Instance.UpdateBackgroundMusicVolume();
            musicText.text = "Unmute Music";
            SoundManager.Instance.MusicMuted = true;
        }
        else
        {
            SoundManager.Instance.musicVolume = SoundManager.Instance.DefaultMusicVolume;
            SoundManager.Instance.UpdateBackgroundMusicVolume();
            musicText.text = "Mute Music";
            SoundManager.Instance.MusicMuted = false;
        }
    }

    private void MuteSoundButtonTaskOnClick()
    {
        if(SoundManager.Instance.SoundMuted == false)
        {
            SoundManager.Instance.soundVolume = 0;
            soundText.text = "Unmute Sounds";
            SoundManager.Instance.SoundMuted = true;
        }
        else
        {
            SoundManager.Instance.soundVolume = SoundManager.Instance.DefaultSoundVolume;
            soundText.text = "Mute Sounds";
            SoundManager.Instance.SoundMuted = false;
        }
    }

}
