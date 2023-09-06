using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class ChaseNode : Node
{
    private NavMeshAgent _agent;
    private Transform _target;
    private EnemyBrain _brain;
    public ChaseNode(Transform target, EnemyBrain brain)
    {
        _target = target;
        _brain = brain;
        _code = NodeActionCode.CHASING;
    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(_target.position, _agent.transform.position);

        if (distance > .2f)
        {
            if (_brain.currentCode != _code)
            {
                _brain.currentCode = _code;
                _brain.TryToTalk("ÃßÀû");
            }
            return NodeState.RUNNING;
        }
        _nodeState = NodeState.SUCCESS;

        return _nodeState;
    }
}
