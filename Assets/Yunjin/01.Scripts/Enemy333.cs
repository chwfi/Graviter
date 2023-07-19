using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy333 : MonoBehaviour
{
    bool flip;
    Vector3 dir;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.position.x < -9)
        {
            dir = Vector3.right;
            flip = true;
        }
        else
        {
            dir = Vector3.left;
        }

        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (flip == true)
        {
            spriteRenderer.flipX = true;
        }
        transform.position += dir * Time.deltaTime * 6;
    }
}