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
    
    private void Start()
    {
        resetPanel.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void UpdateLevelText()
    {
        levelText.text = "Level: " + LevelManager.Instance.LevelsBeaten;
    }
}
