using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _jumpPower = 5f;

    //[SerializeField]
    //private LayerMask Ground;
    //private bool _isGround;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void LateUpdate()
    {
        _rigid.velocity = new Vector2(Mathf.Clamp(_rigid.velocity.x, -2f, 2f), _rigid.velocity.y);
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        _rigid.velocity += new Vector2(x, 0) * _speed;
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(Vector3.up * _jumpPower, ForceMode2D.Impulse);
        }
    }
}
