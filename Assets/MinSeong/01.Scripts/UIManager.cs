using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject effObject;

    float scale = 30;
    float duration = 2;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }

    public void btninput(string sceneName)
    {
        StartCoroutine(BHEvent(sceneName));
    }

    public IEnumerator BHEvent(string sceneName)
    {
        DOTween.KillAll();

        Vector3 pos = new Vector3(0, 0, 0);
        //pos.z = 0;

        GameObject inst = Instantiate(effObject, pos, Quaternion.identity);
        inst.transform.localScale = Vector3.zero;

        inst.transform.DOScale(scale, duration);
        DontDestroyOnLoad (inst);

        yield return new WaitForSeconds(duration);
        LoadScene(sceneName);
        inst.transform.DOScale(0, duration);
        yield return new WaitForSeconds(duration);
        Destroy(inst);


    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
