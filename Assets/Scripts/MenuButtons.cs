using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour
{
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn());
        
    }

    public void OnExitAnimatorButtons()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float duration = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = 1f - (time / duration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
    IEnumerator FadeIn()
    {
        float duration = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = time / duration;
            yield return null;
        }

        canvasGroup.alpha = 1f; 
    }
}