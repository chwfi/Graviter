using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [SerializeField] Animator animator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string name)
    {
        StartCoroutine(Loading(name));
    }

    IEnumerator Loading(string name)
    {
        animator.SetTrigger("scene_start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
        animator.SetTrigger("scene_end");
    }
}
