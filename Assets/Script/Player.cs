using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] public bool _hasKey;
    [SerializeField] private float _health;
    public event Action Interact;
    [SerializeField] public int RegenerationAmount;
    private Coroutine _regernerationRoutine;

    private void Update()
    {
        InteractHandle();

    }

    private void StartRegeneration()
    {

        if (_regernerationRoutine != null)
        {
            StopCoroutine(_regernerationRoutine);
            _regernerationRoutine = null;
        }
        _regernerationRoutine = StartCoroutine(RegernerationRoutine());
    }


    private IEnumerator RegernerationRoutine()
    {
        yield return new WaitForSeconds(3);
        while (_health < 100)
        {
            _health += RegenerationAmount;
            yield return new WaitForSeconds(1);
        }
    }

    public void DamageHit(int damage)
    {
        _health -= damage;
        StartRegeneration();
    }
    private void InteractHandle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact?.Invoke();
        }
    }
}
