using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel;

    public List<GameObject> Levels;


    protected override void Awake()
    {
        base.Awake();
    }

    public void NewLevel()
    {
        WaveSystem.Instance.NextWave();
        currentLevel = Random.Range(0, Levels.Count);
        UpdatePlayerPosForLevelChange();
    }

    public void UpdatePlayerPosForLevelChange()
    {
        Player.CurrentPlayer.Teleport(new Vector3(Levels[currentLevel].GetComponent<LevelData>().PlayerSpawnPoint.transform.position.x, Player.CurrentPlayer.Position.y, Levels[currentLevel].GetComponent<LevelData>().PlayerSpawnPoint.transform.position.z)); ;

    }
}
