using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{//Deni
    public event Action OnhealthUpdate;
    public event Action OnScoreUpdate;
    [SerializeField] public bool _hasKey;
    [SerializeField] public float _health;
    public event Action Interact;
    [SerializeField] public int RegenerationAmount;
    public int _score;
    private Coroutine _regernerationRoutine;

    //Checking here so player don't get over 100hp and when play is dead then it will send the player to death screen
    private void Update()
    {
        InteractHandle();

        if (_health > 100)
        {
            _health = 100;
        }

        if (_health <= 0)
        {
            Debug.LogWarning("U dead");
        }
    }
    //Here we will start our courtine that will regen player helath.
    private void StartRegeneration()
    {

        if (_regernerationRoutine != null)
        {
            StopCoroutine(_regernerationRoutine);
            _regernerationRoutine = null;
        }
        _regernerationRoutine = StartCoroutine(RegernerationRoutine());
    }

    //A regen couretine, if three second coldown has ended, it was start while kiio and start adding health to player.
    // we will invoke our Onhealth event.
    private IEnumerator RegernerationRoutine()
    {
        yield return new WaitForSeconds(5);
        while (_health < 100)
        {
            _health += RegenerationAmount;
            OnhealthUpdate.Invoke();
            yield return new WaitForSeconds(1);
        }
    }
    //This method will damage player, start regen and update UI by sending event signal
    public void DamageHit(int damage)
    {
        _health -= damage;
        StartRegeneration();
        OnhealthUpdate.Invoke();

    }
    //This is going to be our base for the item intreaction that we will refrense in other scripts.
    private void InteractHandle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact?.Invoke();
        }
    }

    //This is to update player score and Invoke Onscore event.
    public void UpdateScore(int score)
    {
        _score += score;
        OnScoreUpdate?.Invoke();
    }
}
