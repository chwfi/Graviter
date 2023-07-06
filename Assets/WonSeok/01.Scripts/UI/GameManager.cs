using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform PlayerTrm;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerTrm = GameObject.FindWithTag("Player").transform;
    }
}
