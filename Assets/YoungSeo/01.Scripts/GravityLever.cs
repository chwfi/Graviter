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

    private bool _isPlayer = false;

    private void Awake()
    {
        _rigids = _obstacles.transform.GetComponentsInChildren<Rigidbody2D>();
    }

    private void OnLever()
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
            _isPlayer = true;
            YSUIManager.Instance.FadeText.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            YSUIManager.Instance.FadeText.FadeIn();

            if (Input.GetKeyDown(KeyCode.F))
            {
                OnLever();
                YSUIManager.Instance.FadeText.GetLever();
            }
        }
        else if (_isPlayer)
        {
            _isPlayer = false;
            YSUIManager.Instance.FadeText.FadeOut();
        }

        if (YSUIManager.Instance.leverTutorial)
        {
            if (Vector2.Distance(GameManager.Instance.PlayerTrm.position, transform.position) <= _tutorialDistance)
            {
                YSUIManager.Instance.TutorialText.FadeInAndOut("Lever");
                YSUIManager.Instance.leverTutorial = false;
            }
        }
    }
}
