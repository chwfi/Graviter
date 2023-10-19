using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SqStates
{
    public class SqIdleState : CommonState<SqBossBrain>
    {
        SqBossBrain _brain;
        int randomNum;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            _brain = ownerEntity;
            Debug.Log("Enter Idle State");

            if (_brain.IsBoltParttern)
            {
                _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.ShootBoltPattern));
                DOTween.Kill(_brain);
            }
            else { _brain.StartCoroutine(SelectRandomPattern()); }
        }

        private IEnumerator SelectRandomPattern()
        {
            yield return new WaitForSeconds(1.5f);

            randomNum = Random.Range(1, 4);

            switch (randomNum)
            {
                case 1:
                    _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.AroundPattern));
                    break;
                case 2:
                    _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.LeftRightPattern));
                    break;
                case 3:
                    _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.RushPattern));
                    break;
                default:
                    
                    break;
            }

            Debug.Log(randomNum);
        }

        public override void OnExitState(SqBossBrain ownerEntity)
        {
            Debug.Log("Exit Idle State");
        }

        public override void UpdateState(SqBossBrain ownerEntity)
        {
            if(Input.GetKeyDown(KeyCode.H))
            {
                _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.AroundPattern));
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.LeftRightPattern));
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.RushPattern));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.ShootBoltPattern));
            }
        }
    }
}

