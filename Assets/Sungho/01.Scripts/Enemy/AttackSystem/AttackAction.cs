using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackActionState
{
    Running,
    Complete,
}

public abstract class AttackAction : ScriptableObject
{
    public float AttackDelay;
    public int NeedAttackCountToCompelete;

    private int _currentAttackCount;
    private AttackActionState _attackState;

    public float CurrentAttackCount
    {
        get => _currentAttackCount;
        set
        {
            _attackState = _currentAttackCount == NeedAttackCountToCompelete ? AttackActionState.Complete : AttackActionState.Running;
        }
    }
    public bool IsComplete => _attackState == AttackActionState.Complete;

    public virtual void Attack(Action action = null)
    {
        ++CurrentAttackCount;

        action?.Invoke();
    }
}
