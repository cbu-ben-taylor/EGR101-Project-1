using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    public GameObject enemyPrefab;

    public float timeBetweenWaves = 10f;
    private float countdown = 2f;

    private static int enemyIncreaser;
    private int enemyCount;

    void Start() 
    {
        enemyIncreaser = 2;
        enemyCount = 0;
    }

    void Update() 
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;    
    }

    IEnumerator SpawnWave ()
    {
        enemyIncreaser++;
        enemyCount = enemyIncreaser / 3;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnEnemy () 
    {
        Instantiate(enemyPrefab, spawnPoint[Random.Range(0,2)].position, spawnPoint[Random.Range(0,2)].rotation);
    }
}
