using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPosition;

    public GameObject enemy;

    public GameObject[] enemies;

    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = spawnPosition.transform.position;
        Instantiate(enemy, spawnPos, transform.rotation);
    }
}
