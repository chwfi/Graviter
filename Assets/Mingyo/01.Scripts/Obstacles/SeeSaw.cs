using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 1f;
    [SerializeField]
    private float distacnce;

    private bool objectOnSeesaw = false;

    [SerializeField]
    private LayerMask _layerMask;

    private void Update()
    {
        CheckObject();

    }

    private void CheckObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * 0.3f, distacnce, _layerMask);
        if (hit.collider != null)
        {
            objectOnSeesaw = true;
        }
    }
}
