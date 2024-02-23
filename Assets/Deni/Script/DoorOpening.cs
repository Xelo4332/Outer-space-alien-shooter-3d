using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Interacteble
{//Deni
    private Player _player;
    [SerializeField] GameObject _Door;
    [SerializeField] GameObject _SecondDoor;
    [SerializeField] GameObject _enemy;
    private Coroutine _attackRoutine;
    [SerializeField] protected bool _isOpened;
    [SerializeField] private int _price;
    
    private int AmmountDoors;
    //this method vill find player
    private void Awake()
    {
        _player = FindObjectOfType<Player>();

    }

    //When we will price E the game will, then activate an event that will send signal to our ui and destroy the door.
    protected override void OnPlayerInteracted()
    {

        if (_player._score >=_price)
        {
            _player.UpdateScore(-_price);
            _UIcanvas.SetActive(false);
            print("dörren öppet");
            Destroy(_Door);

        }


  
    }
}
