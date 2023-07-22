using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public static MapLoader Instance;

    public GameObject[] MapPrefabs;

    public Transform SpawnTrm;

    public Transform InitTrm;
    public int num = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadMap();
    }

    public void LoadMap()
    {
        Instantiate(MapPrefabs[num], SpawnTrm);
        if (num > 0)
        {
            Destroy(GameObject.Find($"Stage{num - 1}(Clone)"));
        }
        num++;
    }
}
