using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    Transform centerPoint;

    [SerializeField]
    float radius = 2f;
    [SerializeField]
    public float speed = 1f;
    [SerializeField]
    private float angle = 0f;

    private void Awake()
    {
        centerPoint = transform.parent.transform;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float y = centerPoint.position.y + radius * Mathf.Sin(angle);

        transform.position = new Vector3(x, y, transform.position.z);

        angle += speed * Time.deltaTime;

        if (angle >= 360f) { angle = 0; }
    }
}
