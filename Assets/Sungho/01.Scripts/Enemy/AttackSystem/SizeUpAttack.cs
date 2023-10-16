using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackSystem/SizeUpAttack", fileName = "AttackAction_SizeUpAttack")]
public class SizeUpAttack : AttackAction
{
    [SerializeField]
    private float ActionPlayTime = 7;
    [SerializeField]
    private float MaxSize = 2.2f;
    private float timer = 0;

    private GameObject _blackhole;
    private Vector2 _maxSize;
    public override void Start()
    {
        base.Start();

        timer = 0;

        _blackhole = attackController.ThisObject.transform.Find("Blackhole").gameObject;
        _maxSize = new Vector2(MaxSize, MaxSize);

        _blackhole.transform.DOScale(_maxSize, 3);
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ActionPlayTime)
        {
            Debug.Log("공격끝남");
            Complete();
        }
    }
    public override void Exit()
    {

    }
}
