using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class BossStartTrigger : MonoBehaviour
{
    public UnityEvent BossBattleStart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            BossBattleStart?.Invoke();
        }
    }
}
