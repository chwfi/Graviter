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
            brain.StartCoroutine(EnterStateCorou());

            Debug.Log("Enter SqLeftRightPattern State");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger -= ChangeState;
            
            brain.MinusStamina();
            Debug.Log("Exit SqLeftRightPattern State");
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {

        }

        private void ChangeState()
        {
            brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.Idle));
        }

        private IEnumerator EnterStateCorou()
        {
            brain.LeftRightPatternWarningZone.SetActive(true);

            yield return new WaitForSeconds(0.7f);

            brain.SqAgentAnimator.SetLeftRightPatternAttack(true);
            brain.LeftRightPatternWarningZone.SetActive(false);
        }
    }
}

