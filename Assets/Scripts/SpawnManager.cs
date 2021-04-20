using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRadius = 8.5f;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    
    private int spawnNumEnemies = 1;
    private int enemyCount;

    private Vector3 getRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRadius, spawnRadius), enemyPrefab.transform.position.y, Random.Range(-spawnRadius, spawnRadius));
    }

    private void spawnWave(int numEnemies)
    {
        Instantiate(powerUpPrefab, getRandomSpawnPosition(), powerUpPrefab.transform.rotation);
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, getRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnWave(spawnNumEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0)
        {
            spawnNumEnemies++;
            spawnWave(spawnNumEnemies);
        }

    }
}
