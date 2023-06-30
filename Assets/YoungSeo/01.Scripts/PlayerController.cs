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

    private Transform _arrowTrm;
    private SpriteRenderer _arrowRenderer;

    private Vector2 _clearPos;

    //[SerializeField]
    //private LayerMask Ground;
    //private bool _isGround;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _clearPos = GameObject.Find("Clear").transform.position;
        _arrowTrm = transform.Find("Arrow");
        _arrowRenderer = _arrowTrm.Find("ArrowVisual").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(FindClearPosition());
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

    IEnumerator FindClearPosition()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _arrowRenderer.color = Color.red;
                float z = Mathf.Atan2(_clearPos.y - _arrowTrm.position.y, _clearPos.x - _arrowTrm.position.x) * Mathf.Rad2Deg - 90;
                _arrowTrm.rotation = Quaternion.Euler(0, 0, z);
                _arrowRenderer.DOFade(0, 1f).SetEase(Ease.InCubic);
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
