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

    [Header("스탯들")]
    public float Speed = 3;
    public float Hp;
    public float Stamina;

    [Header("할당해라")]
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private Slider staminaBar;

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
        hpBar.value = Hp;
        staminaBar.value = Stamina;
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
        Hp -= 10f;
        if (Hp <= 0) { OnDie?.Invoke(); }
        hpBar.value = Hp;
    }

    public void MinusStamina()
    {
        float endValue = Stamina - 10;
        DOTween.To(() => Stamina, x => Stamina = x, endValue, 0.7f).OnUpdate(() => staminaBar.value = Stamina);
        if (Stamina <= 10)
        {
            Debug.Log("스태미나빵");                                           //실행하면 미친개버그 
            //SqBrain.ChangeState(SqBrain.GetState(SqState.ShootBoltPattern));//실행하면 미친개버그 
        }
    }
}