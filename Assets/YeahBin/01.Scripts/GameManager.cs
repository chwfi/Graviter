using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image panelImage;
    public float fadeDuration = 1.0f; // 페이드 지속 시간
    public string nextSceneName = "Stage_8"; // 전환할 씬의 이름


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndDoor"))
        {
            StartCoroutine(FadeAndLoadScene());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("EndDoor2"))
        {
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        panelImage.gameObject.SetActive(true);
        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 1f);

        SceneManager.LoadScene("Stage_8");
    }
}
