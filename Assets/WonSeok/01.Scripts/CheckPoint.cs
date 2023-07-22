using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CheckPoint : MonoBehaviour
{
    private Image _fadePanel;

    private Transform _player;

    private void Start()
    {
        _fadePanel = GameObject.Find("FadePanel").GetComponent<Image>();
        _player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveToNextStage();
        }
    }

    private void MoveToNextStage()
    {
        _fadePanel.DOFade(1, 1f).OnComplete(() =>
        {
            _player.transform.position = MapLoader.Instance.InitTrm.position;
            MapLoader.Instance.LoadMap();
            _fadePanel.DOFade(0, 1f);
        });
    }
}
