using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    [Header("Obstacle Prefabs")]
    [SerializeField] private GameObject[] obstacleAsteroidPrefab;
    [SerializeField] private GameObject obstacleMissilePrefab;
    [SerializeField] private GameObject obstacleLaserPrefab;
    [SerializeField] private GameObject obstacleAvisoPrefab;
    [SerializeField] private GameObject obstacleVerticalLaserPrefab;

    [Header("Spawn Points")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] spawnPointsMissile;
    [SerializeField] private Transform[] spawnPointsLaser;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnInterval = 8f;
    private float timer;



    [Header("Stats")]
    [SerializeField] private float waitforLaser = 2f;
    [HideInInspector] public int asteroidsSpawned;
    [HideInInspector] private bool isDecided;
    [SerializeField] int howManyAsteroids;
    [SerializeField] int howManyMissile;
    [SerializeField] int howManyLaser;
    [SerializeField] int howManyVerticalLaser;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        SpawnInterval();

    }

    private void SpawnAsteroids()
    {
        int prefabIndex = Random.Range(0, obstacleAsteroidPrefab.Length);
        int spawnPointIndexAsteroid = Random.Range(0, spawnPoints.Length);
        Instantiate(obstacleAsteroidPrefab[prefabIndex], spawnPoints[spawnPointIndexAsteroid].position, Quaternion.identity);
        asteroidsSpawned++;
    }

    private void SpawnMissile()
    {
        int spawnPointIndexMissile = Random.Range(0, spawnPointsMissile.Length);
        Instantiate(obstacleMissilePrefab, spawnPointsMissile[spawnPointIndexMissile].position, Quaternion.identity);

    }

    private void SpawnVerticalLaser()
    {
        Instantiate(obstacleVerticalLaserPrefab, new Vector3(15, 0, 0), Quaternion.identity);
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
    private void SpawnInterval()
        {
        if (timer >= spawnInterval && !isDecided)
        {
            timer = 0f;
            DecideWhichObstacleSpawns(); 
        }
    }

    private void DecideWhichObstacleSpawns()
    {
        int randomObstacle = Random.Range(0, 4);
        Debug.Log("randomObstacle: " + randomObstacle);
        switch (randomObstacle)
        {

            case 0:
                if (GameManager.Instance.score >= 1000)
                {
                    StartCoroutine(SpawnMissileRoutine());
                    StartCoroutine(SpawnAsteroidsRoutine());
                }
                else
                {
                    StartCoroutine(SpawnAsteroidsRoutine());
                }
                break;
            case 1:
                if (GameManager.Instance.score >= 1000)
                {
                    StartCoroutine(SpawnAsteroidsRoutine());
                    StartCoroutine(SpawnMissileRoutine());
                }
                else
                {
                    StartCoroutine(SpawnMissileRoutine());
                }
                break;
            case 2:
                if (GameManager.Instance.score >= 1000)
                {
                    StartCoroutine(SpawnMissileRoutine());
                    StartCoroutine(SpawnLaserRoutine());
                } 
                else
                {
                    StartCoroutine(SpawnLaserRoutine());
                }
                break;
            case 3:
                StartCoroutine(SpawnVerticalLaserRoutine());
                break;
        }
    }

  

    private IEnumerator SpawnAsteroidsRoutine()
    {
        isDecided = true;
        for (int i = 0; i < howManyAsteroids; i++)
        {
            SpawnAsteroids();
            yield return new WaitForSeconds(2f);
        }
        isDecided = false;
    }

    private IEnumerator SpawnMissileRoutine()
    {
        isDecided = true;
        for (int i = 0; i < howManyMissile; i++)
        {
            SpawnMissile();
            yield return new WaitForSeconds(2f);
        }
        isDecided = false;
    }

    private IEnumerator SpawnLaserRoutine()
    {
        isDecided = true;
        for (int i = 0; i < howManyLaser; i++)
        {
            StartCoroutine(spawnLaser());
            yield return new WaitForSeconds(4f);
        }
        isDecided = false;
    }

    private IEnumerator SpawnVerticalLaserRoutine()
    {
        isDecided = true;
        for (int i = 0; i < howManyVerticalLaser; i++)
        {
            SpawnVerticalLaser();
            yield return new WaitForSeconds(2f);
        }
        isDecided = false;
    }
}
