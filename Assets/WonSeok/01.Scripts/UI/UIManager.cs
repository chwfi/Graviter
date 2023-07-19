using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public FadeTextMesh FadeText;

    public FadeTextUGUI TutorialText;

    private void Awake()
    {
        Instance = this;
    }
}
