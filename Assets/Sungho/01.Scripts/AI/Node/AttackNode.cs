using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using UnityEngine.AI;

public class AttackNode : Node
{
    private EnemyBrain _brain;
    private float _coolTime = 0;
    private float _lastFireTime = 0;


    public AttackNode(EnemyBrain brain, float coolTime)
    {
        _brain = brain;
        _coolTime = coolTime;

        _code = NodeActionCode.SHOOTING;
    }

    public override NodeState Evaluate()
    {
        if (_brain.currentCode != _code)
        {
            _brain.TryToTalk("���ݻ��·� ��ȯ");
            _brain.currentCode = _code;
        }
        if (_lastFireTime + _coolTime <= Time.time)
        {
            _brain.TryToTalk("����");
            _lastFireTime = Time.time;

            _brain.Attack();
        }
        return NodeState.RUNNING;
    }
}
