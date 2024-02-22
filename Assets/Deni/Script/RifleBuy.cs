using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBuy : Interacteble
{
    //Deni 
    [SerializeField] private GameObject _rifle;
    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _shotgun;
    [SerializeField] private GameObject _smg;
    [SerializeField] private int _price;



    private Player _player;
    //We will find Player script comment 
    void Start()
    {
        _player = FindObjectOfType<Player>();
  

    }

  


    //We ovveride here method and make all object false besides weapon we want.
    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _rifle.SetActive(true);
            _pistol.SetActive(false);
            _shotgun.SetActive(false);
            _smg.SetActive(false);
            _player.UpdateScore(-_price);

        }
    }

 
}
