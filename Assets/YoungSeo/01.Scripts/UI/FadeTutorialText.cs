using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeTutorialText : MonoBehaviour
{
    private Image _textPanel;

    [SerializeField] private float _fadeSpeed = 0.5f;

    public bool CanFade = false;

    private void Start()
    {
        _textPanel = GetComponent<Image>();
    }

    public void FadeInAndOut()
    {
        Time.timeScale = 0;
        Sequence seq = DOTween.Sequence();
        _textPanel.transform.DOScale(Vector3.one, _fadeSpeed).SetUpdate(true);
    }

    public void ClosePanel()
    {
        Time.timeScale = 1;
        _textPanel.transform.DOScale(Vector3.zero, _fadeSpeed).OnComplete(() =>
        {
            _textPanel.gameObject.SetActive(false);
        });
    }
}
