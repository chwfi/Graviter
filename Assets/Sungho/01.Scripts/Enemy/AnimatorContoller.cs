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


    public event Action OnPreAnimationEventTrigger = null; //전조 애니메이션 트리거
    public event Action OnAnimationEventTrigger = null; //애니메이션 내의 이벤트 트리거
    public event Action OnAnimationEndTrigger = null; //애니메이션이 종료될때
    #region 애니메이션 이벤트 영역
    private void OnAnimationEnd() //애니메이션이 종료되면 이게 실행된다.
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
