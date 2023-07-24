using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngineInternal;

public class HUDManager : Singleton<HUDManager>
{
    public TMP_Text levelText;
    public GameObject resetPanel;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    
    private void Start()
    {
        resetPanel.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void UpdateLevelText()
    {
        levelText.text = "Level: " + LevelManager.Instance.LevelsBeaten;
    }
}
