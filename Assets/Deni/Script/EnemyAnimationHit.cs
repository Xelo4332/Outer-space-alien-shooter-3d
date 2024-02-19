using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHit : MonoBehaviour
{

    [SerializeField] private Animator _anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetBool("IsAttack", true);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _anim.SetBool("IsAttack", false);
        }

    }

}
