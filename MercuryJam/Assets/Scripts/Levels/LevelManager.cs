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
    
    [BoxGroup("Levels"), LabelText("All")] public List<Level> levels;

    private Transform _camera;
    private int _levelsBeaten = 0;
    private int _nextLevelIndex;
    private int _currentLevelIndex = 0;

    public void NewLevel()
    {
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
        SpawnManager.Instance.maxEnemies = SpawnManager.Instance.DefaultMaxEnemies;
        NewLevel();

        Player.CurrentPlayer.maxHealth = Player.CurrentPlayer.defaultMaxHealth;
        Player.CurrentPlayer.damage = Player.CurrentPlayer.defaultDamage;
        Player.CurrentPlayer.movementSpeed = Player.CurrentPlayer.defaultMovementSpeed;
        Player.CurrentPlayer.UpdateHealthbar();
    }
    
    private void Start()
    {
        if (Camera.main)
            _camera = Camera.main.transform;
        NewLevel();
    }

    private void UpdatePlayerPosForLevelChange()
    {
        Player.CurrentPlayer.Teleport(
            new Vector3(
                levels[_currentLevelIndex].playerSpawnPoint.position.x,
                Player.CurrentPlayer.Position.y,
                levels[_currentLevelIndex].playerSpawnPoint.position.z));
        if (_camera)
            _camera.position = levels[_currentLevelIndex].cameraLocation.position;
    }
}
