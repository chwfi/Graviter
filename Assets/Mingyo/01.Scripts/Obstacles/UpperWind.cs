using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperWind : MonoBehaviour
{
    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private float jumpPower;


    void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.up, rayDistance, _layerMask);

        if (hits != null)
        {
            foreach (RaycastHit2D hit in hits)
            {
                Vector2 jumpVec = Vector2.up * jumpPower;
                hit.collider.gameObject.transform.position =
                    Vector2.Lerp(hit.collider.gameObject.transform.position, new Vector2(hit.collider.gameObject.transform.position.x, transform.position.y + jumpPower), Time.deltaTime);
                Debug.Log(hit.collider.gameObject.name);
            }
        }

    }
}
