using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    private Animator animator;

    public static int commenceRecoil = 0;

    // Update is called once per frame
    void Update()
    {
        if (commenceRecoil == 1)
        {
            animator.SetTrigger("'HandRecoil");
        }
    }
}
