using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLever : MonoBehaviour
{
    [SerializeField]
    GameObject _obstacles;

    Rigidbody2D[] _rigids;

    [SerializeField] private float _distance;

    [SerializeField] private float _tutorialDistance;

    bool _canFade = true;

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

    private void Update()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(GameManager.Instance.PlayerTrm.position, transform.position) <= _distance)
        {
            //UIManager.Instance.FadeText.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.7f);
            //UIManager.Instance.FadeText.FadeIn();

            if (Input.GetKeyDown(KeyCode.F)) OnLever();
        }
        else
        {
            //UIManager.Instance.FadeText.FadeOut();
        }

        if (_canFade)
        {
            if (Vector2.Distance(GameManager.Instance.PlayerTrm.position, transform.position) <= _tutorialDistance)
            {
                UIManager.Instance.TutorialText.FadeInAndOut();
                _canFade = false;
            }
        }
    }
}
