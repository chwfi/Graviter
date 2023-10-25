using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqAgentAnimator : MonoBehaviour
{
    private Animator _animator;
    public Animator AnimtorCompo => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    #region 애니메이션 이벤트 영역
    public event Action OnPreAnimationEventTrigger = null; //전조 애니메이션 트리거
    public event Action OnAnimationEventTrigger = null; //애니메이션 내의 이벤트 트리거
    public event Action OnAnimationEndTrigger = null; //애니메이션이 종료될때

    public void SetRushPatternAttack(bool value)
    {
        if (value) { _animator.SetTrigger(AnimatorKeys.IsRushAttack); }
        else { _animator.ResetTrigger(AnimatorKeys.IsRushAttack); }
    }

    public void SetAroundPatternAttack(bool value)
    {
        if (value) { _animator.SetTrigger(AnimatorKeys.IsAroundAttack); }
        else { _animator.ResetTrigger(AnimatorKeys.IsAroundAttack); }
    }

    public void SetLeftRightPatternAttack(bool value)
    {
        if (value) { _animator.SetTrigger(AnimatorKeys.IsLeftRightAttack); }
        else { _animator.ResetTrigger(AnimatorKeys.IsLeftRightAttack); }
    }

    public void SetShootBoltPatternStart(bool value)
    {
        if (value) { _animator.SetTrigger(AnimatorKeys.IsLeftRightAttack); }
        else { _animator.ResetTrigger(AnimatorKeys.IsLeftRightAttack); }
    }

    public void OnAnimationEnd() //애니메이션이 종료되면 이게 실행된다.
    {
        OnAnimationEndTrigger?.Invoke();
    }

    public void OnAnimationEvent()
    {
        OnAnimationEventTrigger?.Invoke();
    }

    public void OnPreAnimationEvent()
    {
        OnPreAnimationEventTrigger?.Invoke();
    }
    #endregion
}
