using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGBuy : Interacteble
{
    //Deni
    [SerializeField] private GameObject _rifle;
    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _shotgun;
    [SerializeField] private GameObject _smg;
    [SerializeField] private int _price;



    private Player _player;
    //We will find Player script comment and Animator component.
    void Start()
    {
        _player = FindObjectOfType<Player>();


    }

    //We will overrride the method and use the base of method the script that we innheritance from.


    //We ovveride here method too, so if play score is more than price, then we will play animation, update the score and update the weapon.
    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _rifle.SetActive(false);
            _pistol.SetActive(false);
            _shotgun.SetActive(false);
            _smg.SetActive(true);
            _player.UpdateScore(-_price);

        }
    }

}
