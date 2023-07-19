using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyyj : MonoBehaviour
{
    Vector3 dir;
    void Update()
    {
        if (transform.position.x < 59)
            dir = Vector3.right;
        if (transform.position.x > 90)
            dir = Vector3.left;

        transform.position += Time.deltaTime * dir * 9;
    }
}
