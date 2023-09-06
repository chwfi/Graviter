using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBrain : MonoBehaviour
{
    [SerializeField] protected Transform _targetTrm;

    public NodeActionCode currentCode;
    protected EnemyAttack _enemyAttack;
    protected virtual void Awake()
    {
        _enemyAttack = (EnemyAttack)GetComponent("EnemyAttack");

    }
    protected virtual void Start()
    {

    }
    public void TryToTalk(string text)
    {
        Debug.Log(text);
    }
    public abstract void Attack();
}
