using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{
    [SerializeField] protected Material _material;
    [SerializeField] protected float _scale;
    [SerializeField] protected GameObject _UIcanvas;
    private void Start()
    {
        //_material.SetFloat("_Scale", _scale);

    }


    protected virtual void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact += OnPlayerInteracted;
           // _scale = 1.1f;
           // _material.SetFloat("_Scale", _scale);
            _UIcanvas.SetActive(true);
        }
    }
    //Same as upper script, but here we unsubscribes from the event.

    protected virtual void OnTriggerExit(Collider col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact -= OnPlayerInteracted;
           // _scale = 0;
            //_material.SetFloat("_Scale", _scale);
            _UIcanvas.SetActive(false);
        }
    }
    //We will override this method in other script. 
    protected virtual void OnPlayerInteracted()
    {

    }
   

}

