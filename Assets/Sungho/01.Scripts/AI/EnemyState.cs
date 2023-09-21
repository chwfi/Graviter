using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyState
{
    public class AIState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain brain)
        {

        }

        public override void OnExitState(BossEnemyBrain brain)
        {

        }

        public override void UpdateState(BossEnemyBrain brain)
        {

        }
    }
    public class WalkState : CommonState<BossEnemyBrain>
    {
        public override void OnEnterState(BossEnemyBrain brain)
        {
            brain.coins = 2;
        }

        public override void OnExitState(BossEnemyBrain brain)
        {

        }

        public override void UpdateState(BossEnemyBrain brain)
        {

        }
    }
}
