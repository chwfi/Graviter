using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ppController : MonoBehaviour
{
    public static ppController Instance;

    private void Awake()
    {
        Instance = this;
    }


}
