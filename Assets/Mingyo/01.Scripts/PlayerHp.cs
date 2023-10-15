using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHp : MonoBehaviour
{
    public UnityEvent OnDie;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "SqBoss":
            case "BlackholeBoss":
            case "Obstacle":
                OnDie?.Invoke();
                break;
            case "SqBolt":
                OnDie?.Invoke();
                break;
            default:
                break;
        }
    }

    public void Die()
    {
        _animator.SetBool("IsDie", true);
    }

}
