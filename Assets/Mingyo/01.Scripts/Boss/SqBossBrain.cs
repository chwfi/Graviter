using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqStates;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public enum SqState
{
    Idle,
    AroundPattern,
    LeftRightPattern,
    ShootBoltPattern,

}

public struct AnimatorKeys
{
    public const string IsAroundAttack = "IsAroundAttack";
    public const string IsLeftRightAttack = "IsLeftRightAttack";
}

public class SqBossBrain : MonoBehaviour, IDamageable
{
    public Brain<SqBossBrain> SqBrain = new();

    [SerializeField]
    private UnityEvent OnDie;

    [Header("���ȵ�")]
    public float Speed = 3;
    public float Hp;
    public float Stamina;

    [Header("�Ҵ��ض�")]
    [SerializeField]
    private Slider hpBar;
    public Slider StaminaBar;

    public Bolt BoltPrefab;

    public List<Transform> BoltsTrmList = new List<Transform>();

    private SqAgentAnimator _agentAnimator;
    public SqAgentAnimator SqAgentAnimator => _agentAnimator;

    private void Awake()
    {
        _agentAnimator = transform.Find("Visual").GetComponent<SqAgentAnimator>();
    }

    public void Start()
    {
        DOTween.To(() => StaminaBar.value, x => StaminaBar.value = x, Stamina, 1.5f);
        DOTween.To(() => hpBar.value, x => hpBar.value = x, Hp, 1.5f);

        foreach (Enum item in Enum.GetValues(typeof(SqState)))
        {
            Debug.Log($"SqStates.Sq{item}State");
            var type = Type.GetType($"SqStates.Sq{item}State");
            var instance = Activator.CreateInstance(type) as CommonState<SqBossBrain>;
            SqBrain.StateType.Add(item, instance);
        }

        SqBrain.Setup(this, SqBrain.GetState(SqState.Idle));
    }
    private void Update()
    {
        SqBrain.UpdateState();
    }

    public void OnDamage()
    {
        float endValue = Hp - 10f;
        DOTween.To(() => Hp, x => Hp = x, endValue, 0.7f).OnUpdate(() => hpBar.value = Hp);
        if (Hp <= 0) { OnDie?.Invoke(); }
    }

    public void MinusStamina()
    {
        float endValue = Stamina - 10;
        DOTween.To(() => Stamina, x => Stamina = x, endValue, 0.7f).OnUpdate(() =>
        {
            StaminaBar.value = Stamina;
        }).OnComplete(() =>
        {
        if (Stamina <= 0 && SqBrain.currentState != SqBrain.GetState(SqState.ShootBoltPattern))
            {
                Debug.Log("���¹̳���");
                SqBrain.ChangeState(SqBrain.GetState(SqState.ShootBoltPattern));
                DOTween.Kill(this);
            }
        });
        
    }
}