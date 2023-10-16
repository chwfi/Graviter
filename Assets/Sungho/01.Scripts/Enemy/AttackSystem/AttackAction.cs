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
    private AttackActionState _attackState;
    public AttackActionState AttackState
    {
        get => _attackState;
        set
        {
            _attackState = value;
        }
    }
    protected AttackController attackController;
    public bool IsComplete = false;

    public void SetUpAttackController(AttackController brain)
    {
        attackController = brain;
    }
    public virtual void Start()
    {
        IsComplete = false;
    }
    public abstract void Update();
    public abstract void Exit();
    protected void Complete()
    {
        IsComplete = true;
    }

}
