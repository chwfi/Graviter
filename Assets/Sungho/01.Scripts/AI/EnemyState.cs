using DG.Tweening;
using System.Collections;
using UnityEditor.U2D.Path;
using UnityEngine;

namespace EnemyState
{
    public class IdleState : CommonState<BossEnemyBrain>
    {
        private float waitTimeToNextState = 6.5f;
        private float timer = 0;
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            ownerEntity.transform.DOMove(Vector2.zero, 1);
            ownerEntity.BlackholeObj.transform.DOScale(Vector2.one, 1);

            timer = 0;
            waitTimeToNextState += Random.Range(-3, 3);
        }

        public override void OnExitState(BossEnemyBrain ownerEntity)
        {

        }

        public override void UpdateState(BossEnemyBrain ownerEntity)
        {
            /*if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("���¸� �������·� �������Կ�");
                ownerEntity.Brain.RevertBeforeState();
            }*/
            Debug.Log("���̵����");

            timer += Time.deltaTime;
            if (timer >= waitTimeToNextState)
                ownerEntity.Brain.ChangeState(ownerEntity.Brain.GetState(State.Attack));
        }
    }
    public class AttackState : CommonState<BossEnemyBrain>
    {
        private AttackAction atcAction;
        public override void OnEnterState(BossEnemyBrain ownerEntity)
        {
            atcAction = ownerEntity.AttackController.GetRandomAttackAction(); //����ġ�� ������

            atcAction.SetUpAttackController(ownerEntity.AttackController);
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
