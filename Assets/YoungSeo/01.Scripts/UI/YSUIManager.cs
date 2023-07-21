using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSUIManager : MonoBehaviour
{
    public static YSUIManager Instance;

    public FadeText FadeText;

    public FadeTutorialText TutorialText;

    public bool leverTutorial = true;
    public bool plateTutorial = true;

    private void Awake()
    {
        Instance = this;
    }
}
