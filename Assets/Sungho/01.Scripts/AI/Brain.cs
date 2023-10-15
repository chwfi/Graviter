using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyState;
public class Brain<T> where T : class, new()
{
    private T ownerEntity;

    private CommonState<T> currentState = null; //현재 상태
    private CommonState<T> previousState = null; //이전에 상태
    private CommonState<T> continuousState = null; //계속도는 상태(업데이트에서 계속 돈다고 생각하면 됨)

    public Dictionary<Enum, CommonState<T>> StateType = new();
    public CommonState<T> GetState(Enum e)
    {
        if (StateType.ContainsKey(e))
        {
            return StateType[e];
        }
        Debug.LogError("State가 존재하지 않습니다. State를 추가했는지 확인해보세요.");
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
            Debug.LogError("이전 상태가 없네용");
        else
            ChangeState(previousState);
    }
}
