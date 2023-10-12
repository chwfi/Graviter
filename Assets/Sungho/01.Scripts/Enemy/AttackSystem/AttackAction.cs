using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public enum AttackActionState
{
    Starting,
    Running,
    Exit,
    Complete,
}

public abstract class AttackAction : ScriptableObject
{
    private float timer = 0;

    private AttackActionState _attackState;
    public AttackActionState AttackState
    {
        get => _attackState;
        set
        {
            _attackState = value;
        }
    }
    protected BossEnemyBrain _brain;
    public bool IsComplete => _attackState == AttackActionState.Complete;

    public void SetUpBrain(BossEnemyBrain brain)
    {
        _brain = brain;
    }
    public virtual void Start()
    {
        AttackState = AttackActionState.Starting;
    }
    public virtual void Update()
    {
        AttackState = AttackActionState.Running;
    }
    public virtual void Exit()
    {
        AttackState = AttackActionState.Exit;
    }
    protected void Complete()
    {
        _attackState = AttackActionState.Complete;
    }

}
