using EnemyState;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SqStates
{
    public class SqRushPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain _brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            Debug.Log("아니시발왜또들어와");
            _brain = ownerEntity;
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger += ChangeState;
            _brain.SqAgentAnimator.SetRushPatternAttack(true);
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            Debug.Log("Exit Rush Pattern State");
            ownerEntity.SqAgentAnimator.OnAnimationEndTrigger -= ChangeState;
            _brain.SqAgentAnimator.SetRushPatternAttack(false);
            _brain.MinusStamina();
        }

        private void ChangeState()
        {
            _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.Idle));
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {

        }
    }
}