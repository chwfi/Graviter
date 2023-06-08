using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuButtons : MonoBehaviour
{
    public Button[] buttons;
    public Image[] images;
    RectTransform RectTransform;
    int index = 0;

    [SerializeField] float duration = 2;
    [SerializeField] Transform zero;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index >= buttons.Length - 1)
                index = 0;
            else
                index++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index <= 0)
                index = buttons.Length - 1;
            else
                index--;
        }

        UpdateButton();
    }

    void UpdateButton()
    {
        buttons[index].transform.; //Vector3.Lerp(buttons[index].transform.position, Vector3.zero, duration);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            //buttons[i].transform.position = Vector3.Lerp(buttons[i].transform.position, new Vector3(0, 100*(i - index)), duration);
            buttons[i].transform.DOMove(Vector3.up * 150 * (i - index), duration);
        }
    }
}
