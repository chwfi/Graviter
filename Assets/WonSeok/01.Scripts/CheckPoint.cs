using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject _thisStagePrefab;
    [SerializeField] private GameObject _nextStage;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Image _fadePanel;

    private Transform _player;

    private void Start()
    {
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
            _player.transform.position = _spawnPoint.position;
            _thisStagePrefab.SetActive(false);
            _nextStage.SetActive(true);
            _fadePanel.DOFade(0, 1f);
        });
    }
}
