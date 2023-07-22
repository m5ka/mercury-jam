using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int CurrentWave = 1;
    public int WaveScore = 10;

    public void NextWave()
    {
        CurrentWave++;
        WaveScore = CurrentWave * (10 + CurrentWave);
    }


}
