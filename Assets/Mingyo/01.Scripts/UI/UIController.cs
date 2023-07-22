using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using DG.Tweening.Core;

public class UIController : MonoBehaviour, IAudioPlay
{
    [SerializeField]
    private RectTransform settingPanel;

    [SerializeField]
    private float defaultTrmY;

    bool isOn = false;

    private AudioSource _audioSource;

    private void Awake()
    {
        defaultTrmY = settingPanel.rect.height + 30;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingOnOff();
        }
    }

    public void SettingOnOff()
    {
        settingPanel.DOKill();

        if(isOn)
        {
            settingPanel.DOAnchorPosY(defaultTrmY, 1f).SetEase(Ease.OutExpo).SetUpdate(true); //On
        }
        else
        {
            settingPanel.DOAnchorPosY(defaultTrmY - 1110, 1f).SetEase(Ease.OutExpo).SetUpdate(true); //Off

        }

        isOn = !isOn;
    }

    public void AudioPlay(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
