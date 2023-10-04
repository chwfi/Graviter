using System;
using UnityEngine;
using EnemyState;
public enum State
{
    Idle,
    Walk,
}

public class BossEnemyBrain : MonoBehaviour
{
    public Brain<BossEnemyBrain> Brain = new();

    [Header("½ºÅÈµé")]
    [SerializeField]
    private float _speed = 3;

    private AnimatorContoller _anim;
    public AnimatorContoller Anim => _anim;

    public float Speed => _speed;

    private void Awake()
    {
        _anim = transform.Find("Sprite").GetComponent<AnimatorContoller>();
    }
    public void Start()
    {
        foreach (Enum item in Enum.GetValues(typeof(State)))
        {
            var type = Type.GetType($"EnemyState.{item}State");
            var instance = Activator.CreateInstance(type) as CommonState<BossEnemyBrain>;
            Brain.StateType.Add(item, instance);
        }

        Brain.Setup(this, Brain.GetState(State.Idle));
    }
    private void Update()
    {
        Brain.UpdateState();
    }

}
