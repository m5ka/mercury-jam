using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Button BackButton;
    public Button MuteMusic;
    public Button MuteSound;

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

    }

    void MuteSoundButtonTaskOnClick()
    {

    }

}
