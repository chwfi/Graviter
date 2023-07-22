using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class FadeTutorialText : MonoBehaviour
{
    private Image _textPanel;

    [SerializeField] private float _fadeSpeed = 0.5f;

    public bool CanFade = false;

    private Image _targetImage;
    private TextMeshProUGUI _nameText;
    private TextMeshProUGUI _explainText;

    [SerializeField] private Sprite[] images;

    private string[] names = { "중력 레버", "중력 발판" };

    private string[] explains =
    {
        "근처에서 F키를 눌러 장애물 들의 중력을 반전시킬 수 있습니다.",
        "발판을 눌러 장애물 들의 중력을 반전시킬 수 있습니다."
    };

    private void Start()
    {
        _textPanel = GetComponent<Image>();
        _targetImage = transform.Find("GravityLeverBG/GravityLeverImg").GetComponent<Image>();
        _nameText = transform.Find("GravityLeverBG/GravityLeverText").GetComponent<TextMeshProUGUI>();
        _explainText = transform.Find("ExplainTextPanel/ExplainText").GetComponent<TextMeshProUGUI>();
    }

    public void FadeInAndOut(string senderName)
    {
        SetText(senderName);
        Time.timeScale = 0;
        _textPanel.gameObject.SetActive(true);
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

    private void SetText(string senderName)
    {
        if (senderName == "Lever")
        {
            _targetImage.rectTransform.sizeDelta = new Vector2(50, 100);
            _targetImage.sprite = images[0];
            _nameText.text = names[0];
            _explainText.text = explains[0];
        }
        else
        {
            _targetImage.rectTransform.sizeDelta = new Vector2(80, 8);
            _targetImage.sprite = images[1];
            _nameText.text = names[1];
            _explainText.text = explains[1];
        }
    }
}
