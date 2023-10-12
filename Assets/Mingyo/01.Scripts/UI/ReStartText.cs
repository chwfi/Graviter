using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReStartText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    float alpha;

    private void Update()
    {
        ShowText();
    }

    public void ShowText()
    {
        alpha = Mathf.Sin(Time.time * 5) * 0.4f + 0.6f;

        text.alpha = alpha;
    }
}
