using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SqStates
{
    public class SqAroundPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain _brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            _brain = ownerEntity;
            _brain.SqAgentAnimator.OnAnimationEndTrigger += ChangeState;
            
            _brain.StartCoroutine(EnterStateCorou());

            Debug.Log("Enter AroundPatternState");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            _brain.SqAgentAnimator.OnAnimationEndTrigger -= ChangeState;
            _brain.MinusStamina();

            Debug.Log("Exit AroundPatternState");
        }

        private void ChangeState()
        {
            _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.Idle));
            _brain.MoveAroundPatternWarningZone.SetActive(false);
        }

        private IEnumerator EnterStateCorou()
        {
            _brain.MoveAroundPatternWarningZone.SetActive(true);

            yield return new WaitForSeconds(0.7f);
            _brain.MoveAroundPatternWarningZone.SetActive(false);
            _brain.SqAgentAnimator.SetAroundPatternAttack(true);
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {
            
        }
    }
}
