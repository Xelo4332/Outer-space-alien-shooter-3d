using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    //Deni
    [SerializeField] private int _waveNumber;
    private EnemyWaveSystemSpawner _spawner;

    //Will find Spawner script.
    private void Start()
    {
        _spawner = FindObjectOfType<EnemyWaveSystemSpawner>();
    }

    //If player collides with spawner activater object, that it will activate a new spawn points. Wave number are bassicly a variable to show which room are spawn points located.
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _spawner.ActiveWave(_waveNumber);
        }

    }

}
