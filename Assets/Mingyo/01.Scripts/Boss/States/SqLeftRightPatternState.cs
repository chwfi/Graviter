using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SqStates
{
    public class SqLeftRightPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            brain = ownerEntity;
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger += ChangeState;
            ownerEntity.SqAgentAnimator.SetLeftRightPatternAttack(true);
            Debug.Log("Enter SqLeftRightPattern State");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger -= ChangeState;
            Debug.Log("Exit SqLeftRightPattern State");
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {

        }

        private void ChangeState()
        {
            brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.Idle));
        }
    }
}

