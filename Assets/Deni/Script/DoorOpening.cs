using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Interacteble
{//Deni
   
    [SerializeField] GameObject _Door;
    [SerializeField] GameObject _SecondDoor;
    [SerializeField] private int _price;
    private Player _player;
    private InteractHandler _inter;
    


    private int AmmountDoors;
    //this method vill find player

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _inter = FindObjectOfType<InteractHandler>();
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
            _inter.Interact -= OnPlayerInteracted;
            this.gameObject.SetActive(false);
        }
   

    }


}
