using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private Transform player;
    [SerializeField] private int spawnCount = 5;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        // Shuffle the spawn points array
        for (int i = 0; i < spawnPoints.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, spawnPoints.Length);
            Transform temp = spawnPoints[i];
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }

        // Spawn enemies at the first 'spawnCount' randomly shuffled spawn points
        for (int i = 0; i < Mathf.Min(spawnCount, spawnPoints.Length); i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation,transform);
            enemy.transform.LookAt(player);
        }
    }

}
