using DG.Tweening;
using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class PlayerBossSceneMovement : MonoBehaviour, IAudioPlay
{
    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField]
    private int jumpCount;
    private int maxJumpCount = 1;

    private Rigidbody2D _rb;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Value")]
    [SerializeField] public float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    private Transform _followCam => transform.Find("PlayerFollowCam");

    private float value = 0;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();


    }
    private void Start()
    {
        Init();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("MoveX", horizontal);

        if (IsGrounded()) { _animator.SetFloat("MoveY", 0); jumpCount = maxJumpCount; }
        else { _animator.SetFloat("MoveY", 1); }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            ReverseGravity();
            AudioPlay(_jumpClip);
        }

        Flip();
    }
    private void FixedUpdate()
    {
        _rb.velocity = value % 180 == 0 ?
            new Vector2                                          //아래, 위일때
            (horizontal * speed * (int)transform.right.x,        //x
            _rb.velocity.y)                                      //y
            :
             new Vector2                                         // 왼, 오일때
            (_rb.velocity.x,                                     //x
            horizontal * speed * (int)transform.right.y);        //y
    }
    private void Init()
    {
        StopImmediately();
        Physics2D.gravity = new Vector2(0, -9.81f);
    }
    private void ReverseGravity()
    {
        StopImmediately();

        value = (value + 90) % 360;
        Debug.Log(value);

        Vector2 rotate = value switch
        {
            0 => new Vector2(0, -9.81f), //아래
            90 => new Vector2(9.81f, 0), //오른쪽
            180 => new Vector2(0, 9.81f), //위
            270 => new Vector2(-9.81f, 0), //왼쪽
            _ => new Vector2(0, -9.81f)
        };
        Physics2D.gravity = rotate;
        transform.DORotate(new Vector3(0, 0, value), .7f);
        //_followCam.DORotate(new Vector3(0, 0, value), .7f);
    }
    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void AudioPlay(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void StopImmediately()
    {
        _rb.velocity = Vector3.zero;
    }
}