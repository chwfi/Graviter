using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerGravityAbilty : MonoBehaviour
{
    [SerializeField]
    private LayerMask boltLayerMask;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 2f, Vector2.zero, 0f, boltLayerMask);

            foreach (RaycastHit2D hit in hits)
            {
                hit.transform.GetComponent<Bolt>().RiseUp();
                Vector2 hitPoint = hit.point;
                Vector2 normal = hit.normal;
            }
        }
    }
}
