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

    public void Update()
    {
        Debug.Log("Current Level:" + LevelsBeat);
    }

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
                levels[currentLevel].GetComponent<LevelData>().PlayerSpawnPoint.transform.position.x,
                Player.CurrentPlayer.Position.y,
                levels[currentLevel].GetComponent<LevelData>().PlayerSpawnPoint.transform.position.z));
        CameraManager.Instance.TeleportCamera(
            CameraManager.Instance.mainCamera,
            levels[currentLevel].GetComponent<LevelData>().LevelCamera.transform.position);
    }

    public void ResetGame()
    {
        _levelsBeat = 0;
        NewLevel();
    }
}
