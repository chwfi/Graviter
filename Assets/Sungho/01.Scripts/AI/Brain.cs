using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyState;
public class Brain<T> where T : class, new()
{
    private T ownerEntity;

    private CommonState<T> currentState = null; //���� ����
    private CommonState<T> previousState = null; //������ ����
    private CommonState<T> continuousState = null; //��ӵ��� ����(������Ʈ���� ��� ���ٰ� �����ϸ� ��)

    public Dictionary<Enum, CommonState<T>> StateType = new();
    public CommonState<T> GetState(Enum e)
    {
        if (StateType.ContainsKey(e))
        {
            return StateType[e];
        }
        Debug.LogError("State�� �������� �ʽ��ϴ�. State�� �߰��ߴ��� Ȯ���غ�����.");
        return null;
    }
    public void Setup(T owner, CommonState<T> entryState)
    {
        ownerEntity = owner;

        entryState.SetUp();
        ChangeState(entryState);
    }
    public void UpdateState()
    {
        if (continuousState != null)
        {
            continuousState.UpdateState(ownerEntity);
        }
        if (currentState != null)
        {
            currentState.UpdateState(ownerEntity);
        }

    }
    public void ChangeState(CommonState<T> newState)
    {
        if (newState == null) return;
        if (currentState != null)
        {
            previousState = currentState;

            currentState.OnExitState(ownerEntity);
        }
        currentState = newState;
        currentState.OnEnterState(ownerEntity);
    }
    public void SetContinuousState(CommonState<T> newState)
    {
        continuousState = newState;
    }
    public void RevertBeforeState()
    {
        if (previousState == null)
            Debug.LogError("���� ���°� ���׿�");
        else
            ChangeState(previousState);
    }
}
