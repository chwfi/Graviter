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

        private List<Bolt> boltsList;

        public override void OnEnterState(SqBossBrain ownerEntity)
        {
            boltsList = new List<Bolt>();
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
            for (int i = 0; i < 11; i++)
            {
                Bolt bolt = GameObject.Instantiate(_brain.BoltPrefab, _brain.BoltsTrmList[i].position, _brain.BoltsTrmList[i].rotation);
                boltsList.Add(bolt);
                yield return new WaitForSeconds(0.1f);
            }

            foreach(Bolt bolt in boltsList)
            {
                bolt.Shoot();
            }

            ChangeState();
        }

        private void ChangeState()
        {
            transform.DOMoveY(transform.position.y - 10f, 0.8f).SetEase(Ease.Linear).OnComplete(() =>
            {
                _brain.SqBrain.ChangeState(_brain.SqBrain.GetState(SqState.Idle));
            });
        }
    }
}
