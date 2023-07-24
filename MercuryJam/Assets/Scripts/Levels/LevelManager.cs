using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

[HideMonoScript]
public class LevelManager : Singleton<LevelManager>
{
    [BoxGroup("Levels"), LabelText("All")] public List<GameObject> levels;
    [BoxGroup("Levels"), LabelText("Current")] public int currentLevel;
    private int nextLevel;

    public int LevelsBeat => _levelsBeat;
    private int _levelsBeat = 0;

    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        NewLevel();
    }

    public void NewLevel()
    {
        WaveManager.Instance.NextWave();
        if (levels.Count > 1)
        {
            do
            {
                nextLevel = Random.Range(0, levels.Count);
            } while (nextLevel == currentLevel);

            currentLevel = nextLevel;
        }

        _levelsBeat++;

        UpdatePlayerPosForLevelChange();
        HUDManager.Instance.UpdateLevelText();
    }

    public void UpdatePlayerPosForLevelChange()
    {
        Player.CurrentPlayer.Teleport(
            new Vector3(
                levels[currentLevel].GetComponent<Level>().playerSpawnPoint.position.x,
                Player.CurrentPlayer.Position.y,
                levels[currentLevel].GetComponent<Level>().playerSpawnPoint.position.z));
        CameraManager.Instance.TeleportCamera(
            CameraManager.Instance.mainCamera,
            levels[currentLevel].GetComponent<Level>().cameraLocation.position);
    }

    public void ResetGame()
    {
        _levelsBeat = 0;
        NewLevel();
    }
    
    private void Start()
    {
        BeginGame();
    }

    private void BeginGame()
    {
        NewLevel();
    }
    
    private void UpdatePlayerPosForLevelChange()
    {
        Player.CurrentPlayer.Teleport(
            new Vector3(
                levels[_currentLevelIndex].GetComponent<Level>().playerSpawnPoint.position.x,
                Player.CurrentPlayer.Position.y,
                levels[_currentLevelIndex].GetComponent<Level>().playerSpawnPoint.position.z));
        CameraManager.Instance.Teleport(levels[_currentLevelIndex].GetComponent<Level>().cameraLocation.position);
    }
}
