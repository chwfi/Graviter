using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField]
    AudioMixer _audioMixer;

    [SerializeField]
    List<Slider> sliderList = new List<Slider>();

    private void Start()
    {
        for (int i = 0; i < sliderList.Count; i++)
        {
            if (PlayerPrefs.GetFloat(sliderList[i].name) != 0)
            {
                sliderList[i].value = PlayerPrefs.GetFloat(sliderList[i].name);
            }
            else
            {
                sliderList[i].value = 1;
            }
        }
    }

    public void SoundControll(Slider slider)
    {
        _audioMixer.SetFloat(slider.name, Mathf.Log10(slider.value) * 20);
        PlayerPrefs.GetFloat(slider.name);
    }

    public void ToggleAudioVolume(Toggle toggle)
    {
        int value = toggle.isOn ? 0 : 1;
        _audioMixer.SetFloat(name, value);
    }
}