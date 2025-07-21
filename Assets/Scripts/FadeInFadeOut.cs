using UnityEngine;
using System.Collections;

public class VisionBlocker : MonoBehaviour
{
    public CanvasGroup overlay;        // Trascina qui il CanvasGroup della UI Image
    public float fadeDuration = 1.0f;  // Durata del fade in/out

    public void ShowBlocker(float duration)
    {
        StartCoroutine(FadeBlocker(duration));
    }

    private IEnumerator FadeBlocker(float duration)
    {
        // Fade in
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            overlay.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        // Pausa per la durata visiva della macchia
        yield return new WaitForSeconds(duration);

        // Fade out
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            overlay.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
    }
}
