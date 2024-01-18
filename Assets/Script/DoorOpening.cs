using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Interacteble
{
    [SerializeField] Player _player;
    [SerializeField] GameObject _Door;
    private Coroutine _attackRoutine;
    // Start is called before the first frame update
    private void Awake()
    {
        _player = FindObjectOfType<Player>();

    }
    /*
    protected override void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);
        if (col.gameObject.TryGetComponent(out Player player))
        {
            if (_attackRoutine == null)
            {
                _attackRoutine = StartCoroutine(AttackRoutine());
            }
        }
    }

    protected override void OnTriggerExit(Collider col)
    {
        base.OnTriggerExit(col);
        if (col.gameObject.TryGetComponent(out Player player))
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (gameObject)
        {
            yield return new WaitForSeconds(1);
        }
    }
    */

    // Update is called once per frame
    protected override void OnPlayerInteracted()
    {
        if (_player._hasKey == true)
        {
            _Door.SetActive(false);
            _player._hasKey = false;
        }
        print("d�rren �ppet");

  
    }
}
