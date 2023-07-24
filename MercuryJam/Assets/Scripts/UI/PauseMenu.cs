using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button UnpauseButton;
    public Button OptionsButton;

    private void Start()
    {
        Button unpauseButon = UnpauseButton.GetComponent<Button>();
        Button optionsButton = OptionsButton.GetComponent<Button>();

        unpauseButon.onClick.AddListener(UnpauseTaskOnClick);
        optionsButton.onClick.AddListener(OptionsTaskOnClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.Pause();
            HUDManager.Instance.OpenPauseMenu();
        }
    }

    void UnpauseTaskOnClick()
    {
        GameManager.Instance.Unpause();
        HUDManager.Instance.ClosePauseMenu();
    }

    void OptionsTaskOnClick()
    {
        HUDManager.Instance.OpenOptionsMenu();
        HUDManager.Instance.ClosePauseMenu();
    }
}
