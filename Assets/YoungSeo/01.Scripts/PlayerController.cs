using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _jumpPower = 5f;

    [SerializeField]
    private LayerMask Ground;
    private bool _isGround;

    private float _gravityDir;

    Collider2D coll = null;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerJump();

        //테스트 코드
        float gravityY = Input.GetAxisRaw("Vertical");
        if (gravityY == 0) return;
        _rigid.gravityScale = gravityY * -1;
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
            _gravityDir = _rigid.gravityScale / Mathf.Abs(_rigid.gravityScale);
            _isGround = Physics2D.Raycast(transform.position, Vector3.down, 0.6f * _gravityDir, Ground);
            if (_isGround)
            {
                _rigid.AddForce(Vector3.up * _jumpPower * _gravityDir, ForceMode2D.Impulse);
            }
        }
    }
}
