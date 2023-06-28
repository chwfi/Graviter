using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 1f;

    private bool objectOnSeesaw = false;

    void Update()
    {
        CollionCheck();

        if (objectOnSeesaw)
        {
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed; //¹Ù²Ù°í
            transform.Rotate(Vector3.forward, rotation);
        }
    }

    private void CollionCheck()
    {
        if(Vector3.Distance(transform.position)
    }
}
