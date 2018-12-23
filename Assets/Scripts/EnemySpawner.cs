using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<WaveConfig> waveConfigs;

    private int currentWaveConfig = 0;

    void Start()
    {
        StartCoroutine(ExecuteWaveConfig(this.waveConfigs[this.currentWaveConfig]));
    }

    private IEnumerator ExecuteWaveConfig(WaveConfig waveConfig)
    {
        for (int i = 0; i <= waveConfig.EnemyCount; i++)
        {
            Instantiate(
                waveConfig.EnemyPrefab,
                waveConfig.GetPathPoints()[0].position,
                Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.SpawnRate + Random.Range(0, waveConfig.SpawnRateFactor));
        }
    }
}
