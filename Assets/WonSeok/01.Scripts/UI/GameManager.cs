using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public Transform PlayerTrm;
    [HideInInspector]
    public Transform SpawnTrm;

    [SerializeField]
    PoolingListSO _poolingListSO;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameManager is running! Check!");
        }
        Instance = this;
        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingListSO.List.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }

    private void Start()
    {
        PlayerTrm = GameObject.FindWithTag("Player").transform;
        SpawnTrm = GameObject.Find("SpawnPoint").transform;
    }
}
