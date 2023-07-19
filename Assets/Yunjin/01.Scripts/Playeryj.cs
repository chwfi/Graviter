using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeryj : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject Camera;
    public float moveSpeed = 5f; // 이동 속도
    bool isflip;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Move(moveInput);

        if (Input.GetKeyDown(KeyCode.Space) && isflip == false)
        {
            isflip = true;
            rigid.gravityScale *= -1;
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
    }

    private void Move(float moveInput)
    {
        rigid.velocity = new Vector2(moveInput * moveSpeed, rigid.velocity.y);

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (rigid.gravityScale < 0)
        {
            spriteRenderer.flipY = true;
        }
        else if (rigid.gravityScale > 0)
        {
            spriteRenderer.flipY = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isflip = false;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (rigid.gravityScale < 0)
                rigid.gravityScale *= -1;
            transform.position = spawnpoint.transform.position;
            Camera.transform.position = spawnpoint.transform.position;
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            Debug.Log("스테이지 클리어");
            //스테이지 클리어
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isflip = false;
        if (collision.gameObject.CompareTag("Spawnpoint"))
        {
            Debug.Log("뭐");
            spawnpoint.transform.position = transform.position;
        }
    }
}
