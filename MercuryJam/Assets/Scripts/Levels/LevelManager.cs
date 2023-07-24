using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

[HideMonoScript]
public class LevelManager : Singleton<LevelManager>
{
    public int CurrentLevelIndex => _currentLevelIndex;
    public int LevelsBeaten => _levelsBeaten;
    
    [BoxGroup("Levels"), LabelText("All")] public List<GameObject> levels;
    
    private int _levelsBeaten = 0;
    private int _nextLevelIndex;
    private int _currentLevelIndex = 0;

    public void NewLevel()
    {
        WaveManager.Instance.NextWave();
        if (levels.Count > 1)
        {
            do
            {
                _nextLevelIndex = Random.Range(0, levels.Count);
            } while (_nextLevelIndex == _currentLevelIndex);

            _currentLevelIndex = _nextLevelIndex;
        }

        _levelsBeaten++;

        UpdatePlayerPosForLevelChange();
        HUDManager.Instance.UpdateLevelText();
    }

    public void ResetGame()
    {
        _levelsBeaten = 0;
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
