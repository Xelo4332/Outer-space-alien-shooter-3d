using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnSpots;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private int _startEnemiesCount;

    private void Start()
    {
        CheckSpotsHeight();

        for (int i = 0; i < _startEnemiesCount; i++)
        {
            SpawnEnemy();
        }
        StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnInterval);
        }


    }

    private void SpawnEnemy()
    {
        var randomEnemyIndex = Random.Range(0, _enemies.Length);
        var randomSpawnSpotIndex = Random.Range(0, _spawnSpots.Length);
        Instantiate(_enemies[randomEnemyIndex], _spawnSpots[randomSpawnSpotIndex].position, Quaternion.identity);
    }

    private void CheckSpotsHeight()
    {
        foreach (Transform spawnSpot in _spawnSpots)
        {
            if (spawnSpot.position.y == 0)
            {
                continue;
            }
            else if (spawnSpot.position.y != 0)
            {
                spawnSpot.position = new Vector3(
                    spawnSpot.position.x,
                    0,
                    spawnSpot.position.z
                );
            }
            else
            {
                Debug.Log("This else never will be called :C");
            }
        }
    }


}