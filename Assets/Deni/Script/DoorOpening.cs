using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Interacteble
{//Deni
   

    [SerializeField] private int _price;
    private Player _player;

    


    private int AmmountDoors;
    //this method vill find player

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }


    //When we will price E the game will, then activate an event that will send signal to our ui and destroy the door.
    protected override void OnPlayerInteracted()
    {

        if (_player._score >= _price)
        {
            _player.UpdateScore(-_price);
            print("dörren öppet");
            Debug.Log("MinusPoöng");
            _UIcanvas.SetActive(false);
           _playerInter.Interact -= OnPlayerInteracted;
            this.gameObject.SetActive(false);
        }
   

    }


}
