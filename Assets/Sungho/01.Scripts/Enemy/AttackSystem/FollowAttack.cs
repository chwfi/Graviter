using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackSystem/AttackAction", fileName = "AttackAction_")]
public class FollowAttack : AttackAction
{
    [SerializeField, TextArea]
    private string _description;
    [SerializeField]
    private float FollowTime = 7;
    [SerializeField]
    private float MoveSpeed = 5;

    private float timer = 0;
    private Vector2 targetPos;
    public override void Start()
    {
        base.Start();
        timer = 0;
        targetPos = Vector2.zero;
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= FollowTime)
        {
            Debug.Log("공격끝남");
            Complete();
        }
        else
        {
            targetPos = attackController.PlayerObject.transform.position - attackController.ThisObject.transform.position;

            attackController.ThisObject.transform.Translate(targetPos.normalized * Time.deltaTime * MoveSpeed);
        }
    }

    public override void Exit()
    {

    }

}
