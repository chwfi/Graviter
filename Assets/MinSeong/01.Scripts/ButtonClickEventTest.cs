using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class ButtonClickEventTest : MonoBehaviour
{
    [SerializeField] GameObject effObject;
    [SerializeField] float scale = 10;
    [SerializeField] float duration = 5;

    bool ing = false;

    public void btnInput(string sceneName)
    {
        //UIManager.Instance.BHEvent(sceneName, effObject, scale, duration);
    }

    private void Update()
    {
        if (ing)
        {

        }
    }

    public void BHEvent(string sceneName)
    {
        ing = true; 
        Vector3 pos = Camera.main.ScreenToWorldPoint(transform.position);
        pos.z = 0;
        GameObject inst = Instantiate(effObject, pos, Quaternion.identity);
        StartCoroutine(blackE(sceneName, inst));
    }

    IEnumerator blackE(string sceneName, GameObject inst)
    {
        inst.transform.localScale = Vector3.zero;
        inst.transform.DOScale(scale, duration);
        Debug.Log(inst.transform.localScale.x);
        Debug.Log(scale);
        if (inst.transform.localScale.x >= scale)
        {
            Debug.Log("sjadjdha");
            SceneManager.LoadScene(sceneName);
            inst.transform.DOScale(0, duration);
            yield return null;
        }
    }
}
