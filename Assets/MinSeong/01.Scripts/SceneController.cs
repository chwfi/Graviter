using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    [SerializeField] GameObject image;
    [SerializeField] Animator animator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            LoadScene(GameObject.Find("End")?.GetComponent<NextSceneFlag>().sceneName);
    }

    public void LoadScene(string name)
    {
        StartCoroutine(Loading(name));
    }

    IEnumerator Loading(string name)
    {
        image.SetActive(true);
        animator.SetTrigger("scene_start");
        yield return new WaitForSeconds(1);
            SceneManager.LoadScene(name);
        animator.SetTrigger("scene_end");
        yield return new WaitForSeconds(1);
        image.SetActive(false);
    }
}
