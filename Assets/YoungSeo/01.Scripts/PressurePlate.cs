using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    GameObject _obstacles;
    Rigidbody2D _pressingObj;

    Rigidbody2D[] _rigids;
    
    [SerializeField] private float _tutorialDistance;

    private void Awake()
    {
        _rigids = _obstacles.transform.GetComponentsInChildren<Rigidbody2D>();
    }

    public void OnPress()
    {
        foreach (Rigidbody2D obstacle in _rigids)
        {
            obstacle.gravityScale *= -1;
            if (Vector3.Distance(transform.position, obstacle.transform.position) < 1.2f)
            {
                _pressingObj = obstacle;
                obstacle.gravityScale *= -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPress();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (Rigidbody2D obstacle in _rigids)
        {
            if (obstacle == _pressingObj && !collision.CompareTag("Player")) obstacle.gravityScale *= -1;
            if (Vector3.Distance(transform.position, obstacle.transform.position) < 1.2f)
            {
                _pressingObj = obstacle;
                obstacle.gravityScale *= -1;
            }
            if (collision.CompareTag("Player"))
            {
                obstacle.gravityScale *= -1;
            }
        }
    }

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (YSUIManager.Instance.plateTutorial)
        {
            if (Vector2.Distance(GameManager.Instance.PlayerTrm.position, transform.position) <= _tutorialDistance)
            {
                YSUIManager.Instance.TutorialText.FadeInAndOut("Plate");
                YSUIManager.Instance.plateTutorial = false;
            }
        }
    }
}
