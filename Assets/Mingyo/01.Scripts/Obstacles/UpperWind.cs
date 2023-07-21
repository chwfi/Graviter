using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWind : MonoBehaviour
{
    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private LayerMask _layerMask;



    void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + Vector3.up, Vector2.up, rayDistance, _layerMask);

        if (hits != null)
        {
            foreach (RaycastHit2D hit in hits)
            {
                Vector2 jumpVec = Vector2.up * rayDistance;
                
                hit.rigidbody.AddForce(jumpVec);
                Debug.Log(hit.collider.gameObject.name);
            }
        }

    }
}
