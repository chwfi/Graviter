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
    bool isFirst = true;

    private void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage 1" && isFirst)
        {
            isFirst = false;
            curTime = 0;
        }

        if (SceneManager.GetActiveScene().name == "Clear" && _timerText.gameObject.activeInHierarchy)
        {
            _timerText.gameObject.SetActive(false);
            EndTime = curTime;
        }

        curTime = Time.time;

        _timerText.SetText($"Time: {Mathf.Floor(curTime * 10f) / 10f }");
    }
}
