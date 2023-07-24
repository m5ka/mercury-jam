using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

[HideMonoScript]
public class PauseMenu : MonoBehaviour
{
    [BoxGroup("Buttons"), LabelText("Unpause")] public Button unpauseButton;
    [BoxGroup("Buttons"), LabelText("Settings")] public Button optionsButton;

    private void Start()
    {
        unpauseButton.onClick.AddListener(UnpauseTaskOnClick);
        optionsButton.onClick.AddListener(OptionsTaskOnClick);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            GameManager.Instance.Pause();
            HUDManager.Instance.OpenPauseMenu();
        }
    }

    private void UnpauseTaskOnClick()
    {
        GameManager.Instance.Unpause();
        HUDManager.Instance.ClosePauseMenu();
    }

    private void OptionsTaskOnClick()
    {
        HUDManager.Instance.OpenOptionsMenu();
        HUDManager.Instance.ClosePauseMenu();
    }
}
