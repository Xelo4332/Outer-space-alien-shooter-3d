using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractHandler : MonoBehaviour
{
    public event Action Interact;

    private void Update()
    {
        InteractHandle();
    }
    private void InteractHandle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact?.Invoke();
        }
    }
}
