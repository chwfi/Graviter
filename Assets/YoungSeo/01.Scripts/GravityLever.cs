using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLever : MonoBehaviour
{
    [SerializeField]
    GameObject _obstacles;

    Rigidbody2D[] _rigids;

    private void Awake()
    {
        _rigids = _obstacles.transform.GetComponentsInChildren<Rigidbody2D>();
    }

    public void OnLever()
    {
        foreach (Rigidbody2D obstacles in _rigids)
        {
            obstacles.gravityScale *= -1;
        }
    }
}
