using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] SceneAsset scene;
    bool fdisDone = false;



    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.name);

        while (!asyncOperation.isDone && fdisDone)
        {
            Debug.Log(asyncOperation.progress);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            StartCoroutine(LoadSceneAsync());
        }
    }
}
