using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IAudioPlay
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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("MoveX", horizontal);

        if (IsGrounded()) { _animator.SetFloat("MoveY", 0); jumpCount = maxJumpCount; }
        else { _animator.SetFloat("MoveY", 1); }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            Vector2 jumpvelo = new Vector2(horizontal * speed, _rb.velocity.y + jumpingPower);
            _rb.velocity = jumpCount == 1 ? jumpvelo : jumpvelo * 0.5f;
            jumpCount--;

            //AudioPlay(_jumpClip);
        }
        Flip();

    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);
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