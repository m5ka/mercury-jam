using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    [BoxGroup("Buttons"), LabelText("UpgradeHealth")] public Button UpgradeHealthButton;
    [BoxGroup("Buttons"), LabelText("UpgradeDamage")] public Button UpgradeDamageButton;
    [BoxGroup("Buttons"), LabelText("UpgradeSpeed")] public Button UpgradeSpeedButton;
    [BoxGroup("Buttons"), LabelText("HealPlayer")] public Button HealPlayerButton;

    private void Start()
    {
        UpgradeHealthButton.onClick.AddListener(UpgradeHealthTaskOnClick);
        UpgradeDamageButton.onClick.AddListener(UpgradeDamageTaskOnClick);
        UpgradeSpeedButton.onClick.AddListener(UpgradeSpeedTaskOnClick);
        HealPlayerButton.onClick.AddListener(HealPlayerTaskOnClick);
    }

    public void UpgradeHealthTaskOnClick()
    {
        Player.CurrentPlayer.maxHealth++;
        HUDManager.Instance.CloseUpgradeMenu();
        Player.CurrentPlayer.UpdateHealthbar();
    }
    public void UpgradeDamageTaskOnClick()
    {
        Player.CurrentPlayer.damage++;
        HUDManager.Instance.CloseUpgradeMenu();
    }
    public void UpgradeSpeedTaskOnClick()
    { 
        Player.CurrentPlayer.movementSpeed++;
        HUDManager.Instance.CloseUpgradeMenu();
    }

    public void HealPlayerTaskOnClick()
    {
        Player.CurrentPlayer.HealPlayer(2);
        HUDManager.Instance.CloseUpgradeMenu();
    }


}

