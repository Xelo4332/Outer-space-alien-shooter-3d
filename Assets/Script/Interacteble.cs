using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacteble : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact += OnPlayerInteracted;
        }
    }
    //Same as upper script, but here we unsubscribes from the event.

    protected virtual void OnTriggerExit(Collider col)
    {
        if (col.TryGetComponent(out Player player))
        {
            player.Interact -= OnPlayerInteracted;
        }
    }
    //We will override this method in other script. 
    protected virtual void OnPlayerInteracted()
    {

    }

}

