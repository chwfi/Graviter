using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeTextUGUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [SerializeField] private float _fadeSpeed = 0.5f;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void FadeInAndOut()
    {
        if (_text.alpha <= 0)
        {
            _text.DOFade(1, _fadeSpeed).OnComplete(() =>
            {
                _text.DOFade(0, _fadeSpeed);
            });
        }
    }
}
