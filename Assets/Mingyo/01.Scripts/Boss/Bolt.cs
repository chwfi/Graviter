using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y)) { Shoot(); }
    }

    public void Shoot()
    {
        Debug.Log("asd");
        _rigidbody.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //¹Ù²ã¾ß´ï
        Debug.Log(collision.gameObject.name);
        Destroy(this.gameObject);
    }
}
