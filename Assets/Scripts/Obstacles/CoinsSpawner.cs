using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> coinPositions = new List<Transform>();
    [SerializeField] private GameObject coinPrefab;
    
    void Start()
    {
               StartCoroutine(SpawnCoins());
    }
    IEnumerator SpawnCoins()
    {
        float randomDelay = Random.Range(1.5f, 3f);
        yield return new WaitForSeconds(randomDelay);
        int randomIndex = Random.Range(0, coinPositions.Count);
        Vector3 spawnPosition = coinPositions[randomIndex].position;
        if (Physics2D.OverlapCircle(spawnPosition, 0.1f) != null)
        {
            spawnPosition.x += 2f;
        }
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnCoins());
    }



}
