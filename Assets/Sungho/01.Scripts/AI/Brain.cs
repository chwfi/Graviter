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
    /* public void Setting<A>(CommonState<T> stats) where A : struct
     {
         foreach (var item in Enum.GetValues(typeof(A)))
         {
             states.Add(item, stats);
         }
     }*/
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
    public void RevertBeforeState()
    {
        ChangeState(previousState);
    }
}
