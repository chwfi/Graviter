using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckHP : MonoBehaviour
{
    [SerializeField] SqBossBrain boss;
    [SerializeField] GameObject EndPortal;

    private void Update()
    {
        if(boss.Hp <= 0)
        {
            boss.gameObject.SetActive(false);
            EndPortal.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Delete))
        {
            SceneManager.LoadScene(5);
        }
    }
}
