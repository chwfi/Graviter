using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqStates;

public enum SqState
{
    Idle,
    AroundPattern,
}

public class SqBossBrain : MonoBehaviour
{
    public Brain<SqBossBrain> SqBrain = new();

    [Header("½ºÅÈµé")]
    public float Speed = 3;

    private AnimatorContoller _animator;
    public AnimatorContoller AnimatorControllerCompo => _animator;

    private void Awake()
    {
        _animator = transform.Find("Visual").GetComponent<AnimatorContoller>();
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
