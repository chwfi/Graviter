using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float direction = 1f;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float time = 2f;
    private float lastTurn = 0;

    private void Start()
    {
        lastTurn = Time.time;
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = transform.right * direction * Time.deltaTime * speed;
        transform.Translate(moveDir, Space.World);
        if (lastTurn + time <= Time.time)
        {
            lastTurn = Time.time;
            direction *= -1;
        }
    }

}
