using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public Transform PlayerTrm()
    {
        return GameObject.FindWithTag("Player").transform;
    }
    [HideInInspector]
    public Transform SpawnTrm()
    {
        return GameObject.Find("SpawnPoint").transform;
    }

    [SerializeField]
    PoolingListSO _poolingListSO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingListSO.List.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }

}
