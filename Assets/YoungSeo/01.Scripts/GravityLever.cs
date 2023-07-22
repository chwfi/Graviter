using UnityEngine;

public class GravityLever : MonoBehaviour
{
    [SerializeField]
    GameObject _obstacles;

    Rigidbody2D[] _rigids;

    [SerializeField] private float _distance;

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
        if (Vector2.Distance(GameManager.Instance.PlayerTrm().position, transform.position) <= _distance)
        {
            if (Input.GetKeyDown(KeyCode.F)) OnLever();
        }
    }
}
