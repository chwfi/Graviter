using BehaviourTree;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBrain : EnemyBrain
{
    private Node _topNode;

    protected override void Start()
    {
        base.Start();
        ConstructAITree();
    }

    private void ConstructAITree()
    {
        Transform me = transform;

        RangeNode shootingnRangeNode = new RangeNode(8, _targetTrm, me);
        AttackNode shootNode = new AttackNode(this, 1.5f);
        SequenceNode attackSeq = new(new List<Node> { shootingnRangeNode, shootNode });

        RangeNode chaseRangeNode = new RangeNode(15f, _targetTrm, me);
        ChaseNode chaseNode = new ChaseNode(_targetTrm, this);
        SequenceNode chaseSeq = new(new List<Node> { chaseRangeNode, chaseNode });

        _topNode = new SelectorNode(new List<Node> { attackSeq, chaseSeq });
    }
    private void Update()
    {
        _topNode.Evaluate();

        if (_topNode.nodeState == NodeState.FAILURE && currentCode != NodeActionCode.NONE)
        {
            currentCode = NodeActionCode.NONE;
            TryToTalk("아무것도 할 수 없어");
        }
    }

    public override void Attack()
    {
        _enemyAttack.Attack();
    }

}
