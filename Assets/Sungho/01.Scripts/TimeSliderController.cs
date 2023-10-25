using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeSliderController : MonoBehaviour
{
    [SerializeField]
    private Slider _timeSlider;
    [SerializeField]
    private float setTime = 60f;
    [SerializeField]
    private UnityEvent OnComplated = null;


    private bool isComplated = false;
    private bool isActived = true;
    private float timer = 0;
    void Start()
    {
        isComplated = false;
        isActived = true;
        timer = 0;
    }

    void Update()
    {
        if (isActived == true)
        {
            if (isComplated == false)
            {
                timer += Time.deltaTime;
                if (timer >= setTime) isComplated = true;
                else
                {
                    _timeSlider.value =
                        Mathf.Lerp(_timeSlider.minValue, _timeSlider.maxValue, timer / setTime);
                }

            }
            else if (isComplated == true)
            {
                OnComplated?.Invoke();
                Complate();
            }
        }
    }

    private void Complate()
    {
        SceneManager.LoadScene("Clear");
    }
    public void SetTimerStop()
    {
        isActived = false;
    }
}
