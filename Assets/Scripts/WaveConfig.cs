using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Configuration")]
public class WaveConfig : ScriptableObject
{
	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private GameObject pathPrefab;
	[SerializeField]
	private float spawnRate = 0.5f;
	[SerializeField]
	private float spawnRateFactor = 0.3f;
	[SerializeField]
	private float enemyCount = 5;
	[SerializeField]
	private float moveSpeed = 2f;

    public GameObject EnemyPrefab
    {
        get
        {
            return enemyPrefab;
        }
    }

    public GameObject PathPrefab
    {
        get
        {
            return pathPrefab;
        }
    }

    public float SpawnRate
    {
        get
        {
            return spawnRate;
        }
    }

    public float SpawnRateFactor
    {
        get
        {
            return spawnRateFactor;
        }
    }

    public float EnemyCount
    {
        get
        {
            return enemyCount;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }

	public List<Transform> GetPathPoints()
	{
		var result = new List<Transform>();
		foreach (Transform child in this.pathPrefab.transform)
		{
			result.Add(child);
		}
		return result;
	}
}
