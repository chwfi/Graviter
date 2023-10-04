using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAction : ScriptableObject
{
    private EventHandler onAttackment;

    public event EventHandler OnAttackmentHandle
    {
        add { onAttackment += value; }
        remove { onAttackment -= value; }
    }
    public abstract void Attack();
}
