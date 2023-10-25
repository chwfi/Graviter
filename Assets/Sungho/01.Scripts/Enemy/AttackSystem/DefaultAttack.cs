using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackSystem/AttackAction", fileName = "AttackAction_")]
public class DefaultAttack : AttackAction
{
    [SerializeField, TextArea]
    private string _description;
    public override void Attack()
    {
        AddTask();

        Complete();
    }
}
