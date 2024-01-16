using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : Interacteble
{
    [SerializeField] Player _player;
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    protected override void OnPlayerInteracted()
    {
        if (_player._hasKey == true)
        {
            gameObject.SetActive(false);
            _player._hasKey = false;
        }
        print("dörren öppet");

        if (_player._hasKey == true)
        {

        }
    }
}
