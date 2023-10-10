using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqStates;

public enum SqState
{
    Idle,
    AroundPattern,
    LeftRightPattern,
    ShootBoltPattern,

}

public struct AnimatorKeys
{
    public const string IsAroundAttack = "IsAroundAttack";
    public const string IsLeftRightAttack = "IsLeftRightAttack";
}

public class SqBossBrain : MonoBehaviour
{
    public Brain<SqBossBrain> SqBrain = new();

    [Header("½ºÅÈµé")]
    public float Speed = 3;

    private SqAgentAnimator _agentAnimator;
    public SqAgentAnimator SqAgentAnimator => _agentAnimator;

    private void Awake()
    {
        _agentAnimator = transform.Find("Visual").GetComponent<SqAgentAnimator>();
    }

    public void Start()
    {
        foreach (Enum item in Enum.GetValues(typeof(SqState)))
        {
            Debug.Log($"SqStates.Sq{item}State");
            var type = Type.GetType($"SqStates.Sq{item}State");
            var instance = Activator.CreateInstance(type) as CommonState<SqBossBrain>;
            SqBrain.StateType.Add(item, instance);
        }

        SqBrain.Setup(this, SqBrain.GetState(SqState.Idle));
    }
    private void Update()
    {
        SqBrain.UpdateState();
    }
}
