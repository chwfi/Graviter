using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqIdleState : CommonState<SqBossBrain>
{
    SqBossBrain brain;

    public override void OnEnterState(SqBossBrain ownerEntity)
    {
        brain = ownerEntity;
        //brain.AnimatorControllerCompo.
        Debug.Log("Enter Idle State");
    }

    public override void OnExitState(SqBossBrain ownerEntity)
    {
        Debug.Log("Exit Idle State");
    }

    public override void UpdateState(SqBossBrain ownerEntity)
    {
        throw new System.NotImplementedException();
    }


}
