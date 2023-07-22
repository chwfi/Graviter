using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playeryj : MonoBehaviour
{
    [SerializeField] GameObject spawnpoint;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject[] laser;
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

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("스테이지 클리어");
            //스테이지 클리어
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            collision.gameObject.SetActive(false);
            rigid.gravityScale *= -1;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (rigid.gravityScale < 0)
                rigid.gravityScale *= -1;
            transform.position = spawnpoint.transform.position;
            Camera.transform.position = spawnpoint.transform.position;
            for (int i=0; i < laser.Length; i++)
            {
                Debug.Log("뭐야");
                laser[i].SetActive(true);
            }
        }
    }
}
