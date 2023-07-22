using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using DG.Tweening.Core;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private RectTransform settingPanel;

    [SerializeField]
    private float defaultTrmY;

    bool isOn = false;

    private void Awake()
    {
        defaultTrmY = settingPanel.rect.height + 30;
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



}
