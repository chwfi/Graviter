using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace EnemyState
{

    public class ChaseState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("잘 출력이 되네요 하하");
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("난 아이들인데요 제가 한번 나가볼게요");
        }

        public override void UpdateState(BossEnemyBrain ownerEntity)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ownerEntity.Brain.ChangeState(ownerEntity.Brain.GetState(State.Walk));
            }
        }
    }
    public class WalkState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("안녕하세요 저는 워크스테이트라고 합니다. 저는 상태가 체인지 되었어요.");
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("난 워크인데요 제가 한번 나가볼게요");
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
    public class AttackState : CommonState<BossEnemyBrain>
    {
        private AttackAction atcAction;
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            atcAction = ownerEntity.AttackPattern.GetRandomAttackAction(); //가중치로 가져옴
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
                ownerEntity.Brain.ChangeState(ownerEntity.Brain.GetState(State.Walk));
            }
        }
    }
}
