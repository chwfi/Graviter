using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace SqStates
{
    public class SqShootBoltPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain brain;
        Transform transform;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            brain = ownerEntity;
            //ownerEntity.SqAgentAnimator.OnAnimationEndTrigger += SpawnBolt;
            //ownerEntity.SqAgentAnimator.SetShootBoltPatternStart(true);
            transform = ownerEntity.transform;
            transform.DOMoveY(transform.position.y + 10f, 0.3f).SetEase(Ease.Linear).OnComplete(SpawnBolt);
            Debug.Log("Enter SqShootBoltPattern State");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            //ownerEntity.SqAgentAnimator.OnAnimationEndTrigger -= SpawnBolt;
            Debug.Log("Exit SqShootBoltPattern State");
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {

        }

        private void SpawnBolt()
        {
            Debug.Log("º“»Ø");
            ChangeState();
        }

        private void ChangeState()
        {
            brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.Idle));
        }
    }
}
