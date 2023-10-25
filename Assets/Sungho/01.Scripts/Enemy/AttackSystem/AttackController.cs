using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class AttackPatternList
{
    public AttackAction attackAction;
    [Range(0f, 1.00f)]
    public float weight = .5f;
}

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private List<AttackPatternList> _attackAction = null;

    [Header("공격할때 필요한 요소")]
    public GameObject PlayerObject = null;
    public GameObject ThisObject => gameObject;

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
