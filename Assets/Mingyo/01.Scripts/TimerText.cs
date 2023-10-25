using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;

    float curTime;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        curTime = Time.time;

        _timerText.SetText($"Time: {Mathf.Floor(curTime * 10f) / 10f }");
    }
}
