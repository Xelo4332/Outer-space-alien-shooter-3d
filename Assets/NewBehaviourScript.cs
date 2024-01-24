using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject hands;
    public GameObject fuHands;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && hands.active == true)
        {
            hands.active = false;
            fuHands.active = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && hands.active == false)
        {
            hands.active = true;
            fuHands.active = false;
        }
    }
}
