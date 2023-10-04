using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IAudioPlay
{
    private float horizontal;
    private bool isFacingRight = true;

    private Rigidbody2D _rb;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] UnityEvent OnDie;

    [Header("Value")]
    [SerializeField] private float speed = 8f;
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

        if (IsGrounded()) { _animator.SetFloat("MoveY", 0); Debug.Log("¶¥"); }
        else { _animator.SetFloat("MoveY", 1);  Debug.Log("ÇÑ¸£"); }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y + jumpingPower);

            Debug.Log("das");

            //AudioPlay(_jumpClip);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("321");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _animator.SetBool("isDie", true);
            OnDie?.Invoke();
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
}