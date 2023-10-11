using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace SqStates
{
    public class SqShootBoltPatternState : CommonState<SqBossBrain>
    {
        SqBossBrain _brain;
        Transform transform;

        float bulletsSpaceSize = 30f;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            _brain = ownerEntity;
            //ownerEntity.SqAgentAnimator.OnAnimationEndTrigger += SpawnBolt;
            //ownerEntity.SqAgentAnimator.SetShootBoltPatternStart(true);
            transform = ownerEntity.transform;
            transform.DOMoveY(transform.position.y + 10f, 0.3f).SetEase(Ease.Linear).OnComplete(SpawnBoltHandler);
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

        private void SpawnBoltHandler()
        {
            _brain.StartCoroutine(SpawnBoltCorou());
            
        }

        private IEnumerator SpawnBoltCorou()
        {
            for (int i = 0; i < 7; i++)
            {
                Debug.Log("dasd");
                Bolt bolt = GameObject.Instantiate(_brain.BoltPrefab, _brain.BoltsTrmList[i].position, Quaternion.Euler(_brain.BoltsTrmList[i].position));
                yield return new WaitForSeconds(0.1f);
            }
            ChangeState();

        }

        private void ChangeState()
        {
            _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.Idle));
        }
    }
}
