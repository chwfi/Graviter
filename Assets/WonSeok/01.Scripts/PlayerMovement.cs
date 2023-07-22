using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IAudioPlay
{
    private float horizontal;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip jumpClip;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Value")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            AudioPlay(jumpClip);
        }


        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("321");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Mathf.Abs(rb.velocity.x) > 3f && IsGrounded())
        {
            animator.SetBool("isMove", true);

        }
        else
        {
            animator.SetBool("isMove", false);

        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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