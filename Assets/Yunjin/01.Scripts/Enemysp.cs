using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemysp : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float delayTime = 0.4f;
    IEnumerator enumerator;
    void Start()
    {
        enumerator = SpawnEnemy();
        StartCoroutine(enumerator);
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            int rdIndex = Random.Range(0, transform.childCount);
            enemy.transform.position = transform.GetChild(rdIndex).position;
            yield return new WaitForSeconds(delayTime);
        }
    }
}
