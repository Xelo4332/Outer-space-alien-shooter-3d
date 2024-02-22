using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBuy : Interacteble
{
    //Deni Check riflebuy for comments
    [SerializeField] private GameObject _rifle;
    [SerializeField] private GameObject _pistol;
    [SerializeField] private GameObject _shotgun;
    [SerializeField] private GameObject _smg;
    [SerializeField] private int _price;



    private Player _player;

    void Start()
    {
        _player = FindObjectOfType<Player>();


    }

    protected override void OnPlayerInteracted()
    {
        if (_player._score >= _price)
        {
            _rifle.SetActive(false);
            _pistol.SetActive(false);
            _shotgun.SetActive(true);
            _smg.SetActive(false);
            _player.UpdateScore(-_price);

        }
    }

}
