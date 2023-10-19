using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NextSceneFlag : MonoBehaviour
{
    [SerializeField] SceneAsset sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.LoadScene(sceneName.name);
        }
    }
}
