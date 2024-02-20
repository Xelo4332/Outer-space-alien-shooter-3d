using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IDamageable, ItriggerCheckable
{
    private MoveAi _Ai;
    private Player _player;
    public event Action Ondie;
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #region StateMachine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    

    #endregion
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _Ai = GetComponent<MoveAi>();

        StateMachine = new EnemyStateMachine();

        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);

        _Ai.target = _player.transform; 
    }
    private void Start()
    {

        CurrentHealth = MaxHealth;

        StateMachine.Initialize(ChaseState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
        Debug.Log(StateMachine.CurrentEnemyState);
        Debug.Log(IsWithinStrikingDistance);

    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;

    }


    #region Health/die functions
    public void Damage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
           
        }
    }

    public void Die()
    {
        Ondie.Invoke();
        _player.UpdateScore(1);
        Destroy(gameObject);
    }
    #endregion

    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        Enemydamaged,

    }

    #endregion
}
