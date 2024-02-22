using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{//Deni
    [SerializeField] protected Material _material;
    [SerializeField] protected float _scale;
    [SerializeField] protected GameObject _UIcanvas;


    //Will subscribe to player by a event and activate canvas while player is inside collider
    protected virtual void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact += OnPlayerInteracted;

            _UIcanvas.SetActive(true);
        }
    }

    //Will unsubscribe to player by a event and activate canvas while player is inside collider
    protected virtual void OnTriggerExit(Collider col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact -= OnPlayerInteracted;
            _UIcanvas.SetActive(false);
        }
    }
    //We will override this method in other script. 
    protected virtual void OnPlayerInteracted()
    {

    }
   

}

