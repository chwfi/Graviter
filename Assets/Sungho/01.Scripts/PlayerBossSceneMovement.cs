using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector2(horizontal, 0) * speed * Time.deltaTime);
        _animator.SetFloat("MoveX", horizontal);

        if (IsGrounded()) { _animator.SetFloat("MoveY", 0); jumpCount = maxJumpCount; }
        else { _animator.SetFloat("MoveY", 1); }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            /*  Vector2 jumpvelo = new Vector2(0, _rb.velocity.y + jumpingPower);
              _rb.velocity = jumpCount == 1 ? jumpvelo : jumpvelo * 0.5f;
              jumpCount--;*/

            transform.DOJump(transform.position + transform.up, .5f, 1, .8f);

            AudioPlay(_jumpClip);
        }
        Flip();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
            transform.DORotate(new Vector3(0, 0, 0), .7f);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
            transform.DORotate(new Vector3(0, 0, 180), .7f);

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Physics2D.gravity = new Vector2(-9.81f, 0);
            transform.DORotate(new Vector3(0, 0, 270), .7f);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Physics2D.gravity = new Vector2(9.81f, 0);
            transform.DORotate(new Vector3(0, 0, 90), .7f);

        }
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