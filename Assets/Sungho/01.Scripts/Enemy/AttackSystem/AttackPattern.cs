using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class AttackPatternList
{
    public AttackAction attackAction;
    [Range(0f, 1.00f)]
    public float weight = .5f;
}

public class AttackPattern : MonoBehaviour
{
    [SerializeField]
    private List<AttackPatternList> _attackAction = null;

    private float _totalWeight => _attackAction.Sum(action => action.weight);

    public AttackAction GetRandomAttackAction()
    {
        float randomValue = Random.Range(0f, _totalWeight);
        float cumulativeWeight = 0f;

        foreach (var action in _attackAction)
        {
            cumulativeWeight += action.weight;
            if (randomValue <= cumulativeWeight)
            {
                return action.attackAction;
            }
        }

        Debug.LogError("No Attack Action selected. Check your weights.");
        return null;
    }
}
