using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqAgentAnimator : MonoBehaviour
{
    private Animator _animtor;

    private void Awake()
    {
        _animtor = GetComponent<Animator>();
    }

    #region �ִϸ��̼� �̺�Ʈ ����
    public event Action OnPreAnimationEventTrigger = null; //���� �ִϸ��̼� Ʈ����
    public event Action OnAnimationEventTrigger = null; //�ִϸ��̼� ���� �̺�Ʈ Ʈ����
    public event Action OnAnimationEndTrigger = null; //�ִϸ��̼��� ����ɶ�

    private void OnAnimationEnd() //�ִϸ��̼��� ����Ǹ� �̰� ����ȴ�.
    {
        OnAnimationEndTrigger?.Invoke();
    }

    private void OnAnimationEvent()
    {
        OnAnimationEventTrigger?.Invoke();
    }

    private void OnPreAnimationEvent()
    {
        OnPreAnimationEventTrigger?.Invoke();
    }
    #endregion
}
