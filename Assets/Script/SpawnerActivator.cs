using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    private Player _player;
    private GameObject _enemySpawner;
    private void Start()
    {
       _player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out Player player))
        {
            _enemySpawner.SetActive(true);
        }
    }

}
