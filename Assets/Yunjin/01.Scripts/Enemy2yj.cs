using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2yj : MonoBehaviour
{
    Vector3 dir = Vector3.down;
    private void Start()
    {
        transform.position += Vector3.down * Random.Range(0, 8);
    }
    void Update()
    {
        if (transform.position.y >= 2.2)
            dir = Vector3.down;
        if (transform.position.y <= -6.2)
            dir = Vector3.up;
        transform.position += Time.deltaTime * dir * 6;
    }
}
