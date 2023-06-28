using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeTextUGUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [SerializeField] private float _fadeSpeed = 0.5f;

    public bool CanFade = false;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void FadeInAndOut()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_text.DOFade(1, 1f));
        seq.AppendInterval(2f);
        seq.Append(_text.DOFade(0, 1f)).OnComplete(() =>
        {
            _text.gameObject.SetActive(false);
        });
    }
}
