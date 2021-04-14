using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnRadius = 8.5f;
    public GameObject enemyPrefab;

    private Vector3 getRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRadius, spawnRadius), enemyPrefab.transform.position.y, Random.Range(-spawnRadius, spawnRadius));
    }
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemyPrefab, getRandomSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
