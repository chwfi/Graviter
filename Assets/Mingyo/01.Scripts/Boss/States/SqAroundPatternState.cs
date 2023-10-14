using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SqStates
{
    public class SqAroundPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            brain = ownerEntity;
            brain.SqAgentAnimator.OnAnimationEndTrigger += ChangeState;
            brain.SqAgentAnimator.SetAroundPatternAttack(true);

            Debug.Log("Enter AroundPatternState");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            brain.SqAgentAnimator.OnAnimationEndTrigger -= ChangeState;
            brain.MinusStamina();

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
