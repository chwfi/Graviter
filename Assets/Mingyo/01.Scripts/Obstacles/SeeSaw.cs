using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    [SerializeField]
    float yVec;

    private void Awake()
    {
        yVec = transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, yVec);
    }
}
