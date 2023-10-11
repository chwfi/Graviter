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
    public bool IsComplete => _attackState == AttackActionState.Complete;

    public virtual AttackActionState Start()
    {
        AttackState = AttackActionState.Starting;
        return AttackState;
    }
    public virtual AttackActionState Update()
    {
        AttackState = AttackActionState.Running;
        return AttackState;
    }
    public abstract void Attack(); //무조건적으로 Complete을 마지막에 실행시켜줘야 끝남
    protected void AddTask(float waitTime = 0, Action action = null)
    {

    }
    protected void Complete()
    {
        _attackState = AttackActionState.Complete;
    }

    public virtual AttackActionState Exit()
    {
        AttackState = AttackActionState.Exit;
        return AttackState;
    }
}
