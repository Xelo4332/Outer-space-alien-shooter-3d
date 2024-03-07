using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{//Deni

    [SerializeField] protected GameObject _UIcanvas;
    private InteractHandler _player;
    private void Start()
    {
        _player = FindObjectOfType<InteractHandler>();
    }

    //Will subscribe to player by a event and activate canvas while player is inside collider
    protected virtual void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out InteractHandler player))
        {
            player.Interact += OnPlayerInteracted;

            _UIcanvas.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        _player.Interact -= OnPlayerInteracted; // Unsubscribe if we die
        Debug.Log("Yo i still hapen");
    }
    //Will unsubscribe to player by a event and activate canvas while player is inside collider
    protected virtual void OnTriggerExit(Collider col)
    {
        if (col.TryGetComponent(out InteractHandler player))
        {
            player.Interact -= OnPlayerInteracted;
            _UIcanvas.SetActive(false);
        }
    }
    //We will override this method in other script. 
    protected virtual void OnPlayerInteracted()
    {
        Debug.Log("yo Base call", this);
    }


}

