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
        _audioMixer.SetFloat(slider.name, slider.value);
        PlayerPrefs.GetFloat(slider.name);
    }

    public void ToggleAudioVolume(string name)
    {
        Toggle toggle = transform.Find("Toggles").transform.Find(name).GetComponent<Toggle>();
        Slider slider = transform.Find("Sliders").transform.Find(name).GetComponent<Slider>();

        int value = toggle.isOn ? 0 : -40;

        slider.value = value;
        _audioMixer.SetFloat(name, value);

    }

}