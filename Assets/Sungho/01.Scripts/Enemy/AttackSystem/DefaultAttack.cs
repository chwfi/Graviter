using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : AttackAction
{
    [SerializeField]
    private float castingTime = .2f;

    [SerializeField, TextArea]
    private string _description;

    public override void Attack()
    {
        
    }
    public void Handle()
    {
        
    }
}
