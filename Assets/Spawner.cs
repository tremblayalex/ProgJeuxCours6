using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1;
    public GameObject enemyCubePrefab;

    private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;

    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    void Update()
    {
        UpdateSpawn();
    }

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;

        if (timeLeftBeforeSpawn <= 0)
        {
            SpawnEnemyCube();

            timeLeftBeforeSpawn = spawnRate;
        }
    }

    private void SpawnEnemyCube()
    {
        int spawnPointCount = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, spawnPointCount);
        SpawnPoint currenSpawnPoint = spawnPoints[randomSpawnPointIndex];

        Instantiate(enemyCubePrefab, currenSpawnPoint.transform.position, Quaternion.identity);
    }
}
