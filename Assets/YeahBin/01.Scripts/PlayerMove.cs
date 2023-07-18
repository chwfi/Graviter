using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프에 사용할 힘의 크기
    public bool isJumping = false; // 점프 중인지 여부를 판단하는 변수
    private bool isLongJump = false; // 긴 점프 중인지 여부를 판단하는 변수
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    public Vector3 dir;
    public float distance;

    public GameObject rightDoor;
    public GameObject leftDoor;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        RaycastHit2D isHit = Physics2D.Raycast(transform.position, dir, distance);

        
        Move(moveInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }
    }

    private void Move(float moveInput)
    {
        rigid.velocity = new Vector2(moveInput * moveSpeed, rigid.velocity.y);

        // 이동 방향에 따라 스프라이트 뒤집기
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rigid.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        isLongJump = true;
    }

    private void FixedUpdate()
    {
        if (isLongJump && rigid.velocity.y > 0)
        {
            rigid.gravityScale = 1.0f;
        }
        else
        {
            rigid.gravityScale = 2.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            isLongJump = false;
        }
        if (collision.collider.gameObject.CompareTag("Button"))
        {
            Collider2D rightDoorCollider = GameObject.Find("RightDoor").GetComponent<Collider2D>();
            if (rightDoorCollider != null)
            {
                rightDoorCollider.enabled = false;
                Destroy(rightDoor);
            }
        }
        if (collision.collider.gameObject.CompareTag("Button2"))
        {
            Collider2D leftDoorCollider = GameObject.Find("LeftDoor").GetComponent<Collider2D>();
            if (leftDoorCollider != null)
            {
                leftDoorCollider.enabled = false;
                Destroy(leftDoor);
            }
        }
        if (collision.collider.gameObject.CompareTag("Poison")) // 플레이어 위치 변경
        {       
            Vector3 newPosition = new Vector3(-15.38f, -12.48f, 0f);
            transform.position = newPosition;
        }
        if (collision.collider.gameObject.CompareTag("Poison2")) // 플레이어 위치 변경
        {
            Vector3 newPosition2 = new Vector3(7.86f, -0.37f, 0f);
            transform.position = newPosition2;
        }
        if (collision.collider.gameObject.CompareTag("Poison3")) // 플레이어 위치 변경
        {
            Vector3 newPosition3 = new Vector3(-15.38f, -0.5f, 0f);
            transform.position = newPosition3;
        }
        if (collision.collider.gameObject.CompareTag("EndDoor"))
        {
            SceneManager.LoadScene(1);
        }
        if (collision.collider.gameObject.CompareTag("EndDoor2"))
        {
            SceneManager.LoadScene(2);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + dir) * distance);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, (transform.position + Vector3.up) * distance);
  
    }
}
