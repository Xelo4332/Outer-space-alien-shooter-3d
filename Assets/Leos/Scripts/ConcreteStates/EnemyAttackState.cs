using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Transform target;

    [SerializeField] Player player;

    private Animator anim;

    private float timer;
    private float timeBetweenAttacks = 2;

    private float exitTimer;
    private float timeTillExit;
    private float distanceToCountExit = 3f;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindObjectOfType<Player>();
        anim = GameObject.FindObjectOfType<Animator>();
    }


    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        anim.SetBool("IsAttack", true);
        if (timer > timeBetweenAttacks)
        {
            timer = 0;
            player.DamageHit(25);
            CameraShake.ShakeOnce(0.2f, 1.5f);
            Debug.LogWarning("Damage");
        }

       if(enemy.IsWithinStrikingDistance == false)
        {
            exitTimer += Time.deltaTime;
            if(exitTimer > timeTillExit)
            {
                anim.SetBool("IsAttack", false);
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        }
        timer += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
