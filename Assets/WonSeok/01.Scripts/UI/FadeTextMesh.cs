using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FadeTextMesh : MonoBehaviour
{
    private TextMeshPro _text;

    [SerializeField] private float _fadeSpeed = 0.5f; 

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
    }

    public void FadeIn()
    {
        _text.DOFade(1, _fadeSpeed);
    }

    public void FadeOut()
    {
        _text.DOFade(0, _fadeSpeed);
    }
}
