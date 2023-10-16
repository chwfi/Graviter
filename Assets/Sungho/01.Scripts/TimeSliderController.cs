using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeSliderController : MonoBehaviour
{
    [SerializeField]
    private float setTime = 60f;
    [SerializeField]
    private UnityEvent OnComplated = null;

    private Slider _timeSlider;
    private bool isComplated = false;
    private float timer = 0;
    void Start()
    {
        _timeSlider = GetComponent<Slider>();
        isComplated = false;
        timer = 0;
    }

    void Update()
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

    private void Complate()
    {

    }
}
