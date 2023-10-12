using DG.Tweening;
using System.Collections;
using UnityEditor.U2D.Path;
using UnityEngine;

namespace EnemyState
{
    public class IdleState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            ownerEntity.Anim.IsChase(false);
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {
            
        }

        public override void UpdateState(BossEnemyBrain ownerEntity)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("상태를 이전생태로 돌려볼게요");
                ownerEntity.Brain.RevertBeforeState();
            }
        }
    }
    public class ChaseState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            ownerEntity.Anim.IsChase(true);
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {

        }

        public override void UpdateState(BossEnemyBrain ownerEntity)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ownerEntity.Brain.ChangeState(ownerEntity.Brain.GetState(State.Idle));
            }
        }
    }

    public class AttackState : CommonState<BossEnemyBrain>
    {
        private AttackAction atcAction;
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            atcAction = ownerEntity.AttackController.GetRandomAttackAction(); //가중치로 가져옴

            atcAction.SetUpBrain(ownerEntity);
            atcAction.Start();
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {
            atcAction.Exit();
        }

        public override void UpdateState(BossEnemyBrain ownerEntity)
        {
            atcAction.Update();

            if (atcAction.IsComplete)
            {
                ownerEntity.Brain.ChangeState(ownerEntity.Brain.GetState(State.Idle));
            }
        }
    }
}
