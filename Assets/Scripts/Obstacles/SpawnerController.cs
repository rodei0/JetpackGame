using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private int ObstacleToSpawn;
    [SerializeField] private GameObject[] obstacleAsteroidPrefab;
    [SerializeField] private GameObject obstacleMissilePrefab;
    [SerializeField] private GameObject obstacleLaserPrefab;
    [SerializeField] private GameObject obstacleAvisoPrefab;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] spawnPointsMissile;
    [SerializeField] private Transform[] spawnPointsLaser;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float waitforLaser = 2f;
    private float timer;
    [HideInInspector] public int asteroidsSpawned;


    void Start()
    {
        StartCoroutine(spawnLaser());
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

    private IEnumerator spawnLaser()
    {

        int laserQuantity = Random.Range(1, 5);
        List<int> selectedPositions = new List<int>();
        while (selectedPositions.Count < laserQuantity && selectedPositions.Count < spawnPointsLaser.Length)
        {
            int randomPosition = Random.Range(0, spawnPointsLaser.Length);
            if (!selectedPositions.Contains(randomPosition))
            {
                selectedPositions.Add(randomPosition);
            }
        }
        foreach (int position in selectedPositions)
        {
            Instantiate(obstacleAvisoPrefab, spawnPointsLaser[position].position, Quaternion.identity);
        }
        yield return new WaitForSeconds(waitforLaser);

        foreach (int position in selectedPositions)
        {
            Instantiate(obstacleLaserPrefab, new Vector3(spawnPointsLaser[position].position.x + 1, spawnPointsLaser[position].position.y), Quaternion.identity);
        }
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
