using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpAttack : AttackAction
{
    [SerializeField]
    private float ActionPlayTime = 7;
    [SerializeField]
    private float MaxSize = 2.2f;
    private float timer = 0;

    private GameObject _blackhole;
    private Vector2 _defaultSize;
    private Vector2 _maxSize;
    public override void Start()
    {
        base.Start();
        _blackhole = attackController.ThisObject.transform.Find("Blackhole").gameObject;
        _defaultSize = _blackhole.transform.localScale;
        _maxSize = new Vector2(MaxSize, MaxSize);
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ActionPlayTime)
        {
            Debug.Log("공격끝남");
            Complete();
        }
        else
        {
            _blackhole.transform.localScale = Vector2.Lerp(_blackhole.transform.localScale, _maxSize, timer / 2);
        }
    }
    public override void Exit()
    {
    }
}
