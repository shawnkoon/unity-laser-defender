using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<WaveConfig> waveConfigs;
    [SerializeField]
    private int startWaveIndex = 0;
    [SerializeField]
    private bool isLooped = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(this.ExecuteWaveConfigs());
        } while(this.isLooped);
    }

    private IEnumerator ExecuteWaveConfigs()
    {
        for (int i = startWaveIndex; i < this.waveConfigs.Count; i++)
        {
            yield return StartCoroutine(ExecuteWaveConfig(this.waveConfigs[i]));
        }
    }

    private IEnumerator ExecuteWaveConfig(WaveConfig waveConfig)
    {
        for (int i = 0; i <= waveConfig.EnemyCount; i++)
        {
            var newEnemy = Instantiate(
                waveConfig.EnemyPrefab,
                waveConfig.GetPathPoints()[0].position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.SpawnRate + Random.Range(0, waveConfig.SpawnRateFactor));
        }
    }
}
