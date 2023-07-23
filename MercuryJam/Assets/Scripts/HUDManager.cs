using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngineInternal;

public class HUDManager : Singleton<HUDManager>
{
    public TMP_Text levelText;

    public void UpdateLevelText()
    {
        levelText.text = ("Level: " + LevelManager.Instance.LevelsBeat.ToString());
    }
}