using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace EnemyState
{

    public class ChaseState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("�� ����� �ǳ׿� ����");
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("�� ���̵��ε��� ���� �ѹ� �������Կ�");
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
            Debug.Log("�ȳ��ϼ��� ���� ��ũ������Ʈ��� �մϴ�. ���� ���°� ü���� �Ǿ����.");
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {
            Debug.Log("�� ��ũ�ε��� ���� �ѹ� �������Կ�");
        }

        public override void UpdateState(BossEnemyBrain ownerEntity)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("���¸� �������·� �������Կ�");
                ownerEntity.Brain.RevertBeforeState();
            }
        }
    }
    public class AttackState : CommonState<BossEnemyBrain>
    {
        private AttackAction atcAction;
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            atcAction = ownerEntity.AttackPattern.GetRandomAttackAction(); //����ġ�� ������
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
