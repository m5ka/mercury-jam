using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button BackButton;
    public Button MuteMusic;
    public Button MuteSound;

    public TMP_Text MusicText;
    public TMP_Text SoundText;

    public void Start()
    {
        Button backButton = BackButton.GetComponent<Button>();
        Button muteMusic = MuteMusic.GetComponent<Button>();
        Button muteSound = MuteSound.GetComponent<Button>();

        backButton.onClick.AddListener(BackButtonTaskOnClick);
        muteMusic.onClick.AddListener(MuteMusicButtonTaskOnClick);
        muteSound.onClick.AddListener(MuteSoundButtonTaskOnClick);
    }

    void BackButtonTaskOnClick()
    {
        HUDManager.Instance.OpenPauseMenu();
        HUDManager.Instance.CloseOptionsMenu();
    }

    void MuteMusicButtonTaskOnClick()
    {
        if (SoundManager.Instance.MusicMuted == false)
        {
            SoundManager.Instance.musicVolume = 0;
            SoundManager.Instance.UpdateBackgroundMusicVolume();
            MusicText.text = "unmute music";
            SoundManager.Instance.MusicMuted = true;
        }
        else
        {
            SoundManager.Instance.musicVolume = SoundManager.Instance.DefaultMusicVolume;
            SoundManager.Instance.UpdateBackgroundMusicVolume();
            MusicText.text = "mute music";
            SoundManager.Instance.MusicMuted = false;
        }
    }

    void MuteSoundButtonTaskOnClick()
    {
        if(SoundManager.Instance.SoundMuted == false)
        {
            SoundManager.Instance.soundVolume = 0;
            SoundText.text = "unmute sounds";
            SoundManager.Instance.SoundMuted = true;
        }
        else
        {
            SoundManager.Instance.soundVolume = SoundManager.Instance.DefaultSoundVolume;
            SoundText.text = "mute sounds";
            SoundManager.Instance.SoundMuted = false;
        }
    }

}
