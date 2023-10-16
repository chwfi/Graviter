using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private readonly string _playerTagName = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != _playerTagName) return;
        if (collision.gameObject.TryGetComponent<StageReStart>(out var component))
        {
            component?.ReStartScene();
        }
    }
}
