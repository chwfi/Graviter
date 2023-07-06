using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleObstacle : PoolableMono
{
    [SerializeField]
    private int goalTime;

    [SerializeField]
    private float rayDistance;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private int timer = 0;

    Rigidbody2D rb;

    public override void Init()
    {
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        StartCoroutine(ObstacleCoroutine());
    }

    private void Start()
    {
        Init();
    }

    private IEnumerator ObstacleCoroutine()
    {
        while(timer <= goalTime)
        {
            timer += 1;
            yield return new WaitForSeconds(1f);
        }

        rb.gravityScale = 1.0f;
    }

    private void Update()
    {
        if(Physics2D.Raycast(transform.position, -transform.up, rayDistance, layerMask))
        {
            PoolManager.Instance.Push(this);
        }
    }
}
