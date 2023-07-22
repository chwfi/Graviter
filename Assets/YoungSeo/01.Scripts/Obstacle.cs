using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.transform.position = GameManager.Instance.SpawnTrm().position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.transform.position = GameManager.Instance.SpawnTrm().position;
            if (this.gameObject.name == "thorn") Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
