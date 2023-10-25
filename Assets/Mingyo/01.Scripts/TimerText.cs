using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;

    float curTime;
    public static float EndTime;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Clear")
        {
            _timerText.gameObject.SetActive(false);
            EndTime = curTime;
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        curTime = Time.time;

        _timerText.SetText($"Time: {Mathf.Floor(curTime * 10f) / 10f }");
    }
}
