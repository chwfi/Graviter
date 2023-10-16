using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpsideDownPlayer : MonoBehaviour, IAudioPlay
{
    private float horizontal;
    private bool isFacingRight = true;
/*    [SerializeField]
    private int jumpCount;
    private int maxJumpCount = 1;*/

    private bool isFlip = false;

    private Rigidbody2D _rb;
    private Animator _animator;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

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
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("MoveX", horizontal);

        if (IsGrounded()) { _animator.SetFloat("MoveY", 0); }
        else { _animator.SetFloat("MoveY", 1); }

        if (Input.GetKeyDown(KeyCode.Space) && !isFlip)
        {
            _rb.gravityScale *= -1;
            isFlip = true;
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

        if(_rb.gravityScale > 0)
        {
            _spriteRenderer.flipY = false;
        }
        else
        {
            _spriteRenderer.flipY = true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isFlip = false;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_rb.gravityScale < 0)
                _rb.gravityScale *= -1;
            //transform.position = spawnpoint.transform.position;
            //Camera.transform.position = spawnpoint.transform.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("스테이지 클리어");
            //스테이지 클리어
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            collision.gameObject.SetActive(false);
            _rb.gravityScale *= -1;
        }
    }
}
