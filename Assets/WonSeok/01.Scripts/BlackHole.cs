using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rigid;
    [Header("Shames")]
    [SerializeField] private Transform _playerPos;
    [SerializeField] private float _pullSpeed = 1;
    [SerializeField] private float _maxDis;
    private float _dis;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PullPlayer();
    }

    private bool CheckDistance()
    {
        _dis = Vector2.Distance(_playerPos.position, transform.position);
        if (_dis <= _maxDis)
            return true;
        else
            return false;
    }

    private void PullPlayer()
    {
        if (_playerPos != null && CheckDistance())
            _playerPos.position += transform.position * Time.deltaTime * _pullSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
