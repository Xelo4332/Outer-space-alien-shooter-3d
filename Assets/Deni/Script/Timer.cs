using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Deni
    //We are creating three variables for Health component, timer and time
    private Player _playerHealth;
    [SerializeField] private Text _timerLabel;
    private int _time;

    //Program searching Object named Health, if player is dead then time is saved and we are using tick method
    private void Start()
    {
        _playerHealth = FindObjectOfType<Player>();
        _playerHealth.PlayerIsDead += Save;
        StartCoroutine(Tick());
    }
    //And number value +1
    private IEnumerator Tick()
    {
        while (true)
        {
            _time++;
            yield return new WaitForSeconds(1);
            _timerLabel.text = "Time: " + _time.ToString();
        }
    }
    //Saves record
    private void Save()
    {
        PlayerPrefs.SetInt("record", _time);
    }
    //Destroying Timer when player is dead
    private void OnDestroy()
    {
        _playerHealth.PlayerIsDead -= Save;
    }
}
