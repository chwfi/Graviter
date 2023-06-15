using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSample : MonoBehaviour
{
    [Header("이것저것")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    bool _canJump = false;

    [Header("Components")]
    private Vector3 _dir;
    private Rigidbody2D _rigid;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _canJump = true;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        _dir = new Vector3(x, 0, 0);

        _rigid.velocity = _dir.normalized * _moveSpeed;

        if (_canJump)
        {
            _canJump = false;
             _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
           
    }
}
