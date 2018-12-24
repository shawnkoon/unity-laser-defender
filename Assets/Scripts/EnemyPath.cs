using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    private WaveConfig waveConfig;
    private List<Transform> pathPoints;
    private int wayPointIndex = 0;

    private void Start()
    {
        this.pathPoints = this.waveConfig.GetPathPoints();
        this.transform.position = this.pathPoints[0].position;
    }

    private void Update()
    {
        this.MoveEnemy();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void MoveEnemy()
    {
        if (this.wayPointIndex < this.pathPoints.Count)
        {
            var targetPosition = this.pathPoints[this.wayPointIndex].position;
            var enemySpeed = this.waveConfig.MoveSpeed * Time.deltaTime;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, enemySpeed);

            if (this.transform.position == targetPosition)
            {
                this.wayPointIndex++;
            }
        }
        else
        {
            Destroy(base.gameObject);
        }
    }
}
