using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FadeText : MonoBehaviour
{
    private TextMeshPro _text;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _fadeSpeed = 0.5f;

    private bool _isFade = false;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _spriteRenderer = _text.transform.GetComponentInChildren<SpriteRenderer>();
    }

    public void FadeIn()
    {
        if (!_isFade)
        {
            _isFade = true;
            _text.DOFade(1, _fadeSpeed);
            _spriteRenderer.DOFade(1, _fadeSpeed);
        }
    }

    public void FadeOut()
    {
        _isFade = false;
        _text.DOFade(0, _fadeSpeed);
        _spriteRenderer.DOFade(0, _fadeSpeed);
    }

    public void GetLever()
    {
        _text.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        _spriteRenderer.color = new Color(0.75f, 0.75f, 0.75f, 1f);
        _text.DOColor(Color.black, _fadeSpeed);
        _spriteRenderer.DOColor(Color.white, _fadeSpeed);
    }
}
