using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Transform target;

    [SerializeField] Player player;

    private float timer;
    private float timeBetweenAttacks = 2;

    private float exitTimer;
    private float timeTillExit;
    private float distanceToCountExit = 3f;
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindObjectOfType<Player>();
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

       if(timer > timeBetweenAttacks)
        {
            timer = 0;
            player.DamageHit(10);
            Debug.Log("haha ur damgaed");

        }

       if(enemy.IsWithinStrikingDistance == false)
        {
            exitTimer += Time.deltaTime;
            if(exitTimer > timeTillExit)
            {
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
