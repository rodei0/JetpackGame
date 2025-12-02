using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private int ObstacleToSpawn;
    [SerializeField] private GameObject[] obstacleAsteroidPrefab;
    [SerializeField] private GameObject obstacleMissilePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] spawnPointsMissile;

    [SerializeField] private float spawnInterval = 2f;
    private float timer;
    [HideInInspector] public int asteroidsSpawned;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        SpawnInterval();

    }

    void SpawnPrefab()
    {
        int prefabIndex = Random.Range(0, obstacleAsteroidPrefab.Length);
        int spawnPointIndexAsteroid = Random.Range(0, spawnPoints.Length);
        Instantiate(obstacleAsteroidPrefab[prefabIndex], spawnPoints[spawnPointIndexAsteroid].position, Quaternion.identity);
        asteroidsSpawned++;
    }

    void SpawnMissile()
    {
        int spawnPointIndexMissile = Random.Range(0, spawnPointsMissile.Length);
        Instantiate(obstacleMissilePrefab, spawnPointsMissile[spawnPointIndexMissile].position, Quaternion.identity);
    }
    void SpawnInterval()
        {
        if (timer >= spawnInterval)
        {
            SpawnMissile();
            SpawnPrefab();
            timer = 0f;
        }
    } 
}
