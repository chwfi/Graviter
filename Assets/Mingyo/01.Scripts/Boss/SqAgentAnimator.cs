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

    #region �ִϸ��̼� �̺�Ʈ ����
    public event Action OnPreAnimationEventTrigger = null; //���� �ִϸ��̼� Ʈ����
    public event Action OnAnimationEventTrigger = null; //�ִϸ��̼� ���� �̺�Ʈ Ʈ����
    public event Action OnAnimationEndTrigger = null; //�ִϸ��̼��� ����ɶ�

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

    public void OnAnimationEnd() //�ִϸ��̼��� ����Ǹ� �̰� ����ȴ�.
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
