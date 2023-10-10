using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SqStates
{
    public class SqIdleState : CommonState<SqBossBrain>
    {
        SqBossBrain brain;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            brain = ownerEntity;
            Debug.Log("Enter Idle State");
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            Debug.Log("Exit Idle State");
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {
            Debug.Log("Idle ½Ã·©Áß");

            if (Input.GetKeyDown(KeyCode.J))
            {
                brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.AroundPattern));
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.LeftRightPattern));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                brain.SqBrain.ChangeState(brain.SqBrain.GetState(SqState.ShootBoltPattern));
            }
        }
    }
}

