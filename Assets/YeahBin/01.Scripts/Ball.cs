using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject LeftBall;
    public GameObject RightBall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D BallDoorRight = GameObject.Find("BallDoor_Right").GetComponent<Collider2D>();
        BallDoorRight.enabled = false;

        if (collision.collider.gameObject.CompareTag("BallButton1"))
        {
            Collider2D BallDoorLeft = GameObject.Find("BallDoor_Left").GetComponent<Collider2D>();
            if (BallDoorLeft != null)
            {
                BallDoorLeft.enabled = false;
                BallDoorRight.enabled = true;
            }
        }

        Collider2D EndDoor = GameObject.Find("EndDoor").GetComponent<Collider2D>();
        EndDoor.enabled = false;
        if (collision.collider.gameObject.CompareTag("BallButton2"))
        {
            EndDoor.enabled = true;
        }

       
    }
}
