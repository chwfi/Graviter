using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Blackhole : MonoBehaviour
{
    public const float GRAVITY_PULL = 7000.0f;
    private const float SWIRLSTRENGTH = 5f;

    private float _gravityRadius = 7.0f;
    private List<Rigidbody2D> _rigidBodies = new List<Rigidbody2D>();
    void Update()
    {
        if (Application.isPlaying == false)
        {
            _gravityRadius =
                GetComponent<CircleCollider2D>().radius;
        }
    }

    private void LateUpdate()
    {
        UpdateBlackHole();
    }


    void OnTriggerEnter2D(Collider2D in_other)
    {
        if (in_other.attachedRigidbody != null
            && _rigidBodies != null)
        {
            Vector3 direction =
                    transform.position - in_other.attachedRigidbody.transform.position;
            var tangent =
                    Vector3.Cross(direction, Vector3.forward).normalized * SWIRLSTRENGTH;

            in_other.attachedRigidbody.velocity = tangent;
            _rigidBodies.Add(in_other.attachedRigidbody);
        }
    }

    private void UpdateBlackHole()
    {
        if (_rigidBodies != null)
        {
            for (int i = 0; i < _rigidBodies.Count; i++)
            {
                if (_rigidBodies[i] != null)
                {
                    CalculateMovement(_rigidBodies[i]);
                }
            }
        }
    }



    private void CalculateMovement(Rigidbody2D in_rb)
    {
        float distance = Vector3.Distance(transform.position, in_rb.transform.position);

        float gravityIntensity = distance / _gravityRadius;

        in_rb.AddForce(transform.position - in_rb.transform.position);

    }
}

