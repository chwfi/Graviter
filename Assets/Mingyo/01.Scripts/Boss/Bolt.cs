using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody2D _rigidbody;
    CircleCollider2D _circleCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)) { Shoot(); }
    }

    public void Shoot()
    {
        Debug.Log("asd");
        _rigidbody.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ٲ�ߴ�
        _rigidbody.gravityScale = 1;
        _circleCollider.isTrigger = false;

        if (collision.CompareTag("Player") || collision.CompareTag("SqBoss"))
        {
            if(collision.TryGetComponent(out IDamageable hit))
            {
                Debug.Log($"Hit{collision.name}");
                hit.OnDamage();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log($"Hit{collision.name}");
            }
        }
    }

    public void RiseUp()
    {
        _rigidbody.velocity = Vector2.up * speed;
    }

}
