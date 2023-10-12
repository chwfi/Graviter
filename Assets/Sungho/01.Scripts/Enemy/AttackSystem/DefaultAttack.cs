using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackSystem/AttackAction", fileName = "AttackAction_")]
public class DefaultAttack : AttackAction
{
    [SerializeField, TextArea]
    private string _description;
    public override void Start()
    {
        base.Start();

        _brain.Anim.OnPreAnimationEventTrigger += OnPreAnimHandle;
        _brain.Anim.OnAnimationEndTrigger += OnEndAnimHandle;
        _brain.Anim.OnAnimationEventTrigger += OnEventAnimHandle;
    }

    private void OnPreAnimHandle()
    {

    }
    private void OnEventAnimHandle()
    {
        _brain.AttackController.attackArea.SetActive(true);
    }

    private void OnEndAnimHandle()
    {
        _brain.AttackController.attackArea.SetActive(false);

        Complete();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();

        _brain.Anim.OnPreAnimationEventTrigger -= OnPreAnimHandle;
        _brain.Anim.OnAnimationEndTrigger -= OnEndAnimHandle;
        _brain.Anim.OnAnimationEventTrigger -= OnEventAnimHandle;
    }

}
