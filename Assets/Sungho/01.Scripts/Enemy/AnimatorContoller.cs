using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorContoller : MonoBehaviour
{
    private Animator anim;
    private readonly string H_Chase = "Chase";
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public event Action OnPreAnimationEventTrigger = null; //���� �ִϸ��̼� Ʈ����
    public event Action OnAnimationEventTrigger = null; //�ִϸ��̼� ���� �̺�Ʈ Ʈ����
    public event Action OnAnimationEndTrigger = null; //�ִϸ��̼��� ����ɶ�

    public void IsChase(bool value)
    {
        anim.SetBool(H_Chase, value);
    }

    #region �ִϸ��̼� �̺�Ʈ ����
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
