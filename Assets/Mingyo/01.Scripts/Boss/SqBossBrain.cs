using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqStates;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public enum SqState
{
    Idle,
    AroundPattern,
    LeftRightPattern,
    ShootBoltPattern,
    RushPattern,

}

public struct AnimatorKeys
{
    public const string IsAroundAttack = "IsAroundAttack";
    public const string IsLeftRightAttack = "IsLeftRightAttack";
    public const string IsRushAttack = "IsRushAttack";
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
    public Slider StaminaBar;
    public GameObject LeftRightPatternWarningZone;
    public GameObject MoveAroundPatternWarningZone;
    [SerializeField]
    private TextMeshPro hudText;

    public Bolt BoltPrefab;

    public List<Transform> BoltsTrmList = new List<Transform>();

    private SqAgentAnimator _agentAnimator;
    public SqAgentAnimator SqAgentAnimator => _agentAnimator;

    public bool IsBoltParttern => Stamina <= 10;

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

    public void OnDamage(Vector2 normal)
    {
        float endValue = Hp - 10f;
        DOTween.To(() => Hp, x => Hp = x, endValue, 0.7f).OnUpdate(() => hpBar.value = Hp);

        hudText.transform.localPosition = normal;   
        hudText.color = Color.white;

        Vector2 endVecValue = normal + new Vector2(normal.x, -12f);

        hudText.rectTransform.DOLocalMoveY(endVecValue.y, 0.5f).OnComplete(() =>
        {
            DOTween.To(() => hudText.color, r => hudText.color = r, new Color(0,0,0,0), 0.5f); 
        });


        if (Hp <= 0) { OnDie?.Invoke(); }
    }

    public void MinusStamina()
    {
        float endValue = Stamina - 10;
        DOTween.To(() => Stamina, x => Stamina = x, endValue, 0.7f).OnUpdate(() =>
        {
            StaminaBar.value = Stamina;
        });
    }
}