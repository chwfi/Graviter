using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SqStates
{
    public class SqLeftRightPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain _brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            _brain = ownerEntity;
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger += ChangeState;
            _brain.StartCoroutine(EnterStateCorou());

            Debug.Log("Enter SqLeftRightPattern State");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger -= ChangeState;

            _brain.MinusStamina();
            Debug.Log("Exit SqLeftRightPattern State");
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {

        }

        private void ChangeState()
        {
            _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.Idle));
        }

        private IEnumerator EnterStateCorou()
        {
            _brain.LeftRightPatternWarningZone.SetActive(true);

            yield return new WaitForSeconds(0.7f);

            _brain.SqAgentAnimator.SetLeftRightPatternAttack(true);
            _brain.LeftRightPatternWarningZone.SetActive(false);
        }
    }
}

