using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SqStates
{
    public class SqAroundPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            brain = ownerEntity;
            brain.AnimatorControllerCompo.OnAnimationEndTrigger += ChangeState;

            Debug.Log("Enter AroundPatternState");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            brain.AnimatorControllerCompo.OnAnimationEndTrigger -= ChangeState;

            Debug.Log("Exit AroundPatternState");
        }

        private void ChangeState()
        {
            brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.Idle));
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {
            
        }
    }
}
