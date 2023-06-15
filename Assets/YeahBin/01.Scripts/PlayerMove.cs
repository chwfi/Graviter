using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Player_speed;
    public int jumPower;
    public Vector3 dir;
    bool isjumping;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        isjumping = false;
    }


    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        dir = new Vector3(x, 0);
        transform.position += dir.normalized * Player_speed * Time.deltaTime;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isjumping)
            {
                isjumping = true;
                rigid.AddForce(Vector3.up * jumPower, ForceMode2D.Impulse);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isjumping = false;
        }
    }
}
