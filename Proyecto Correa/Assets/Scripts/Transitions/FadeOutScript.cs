using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroSequence : MonoBehaviour
{
    public Image backgroundImage;          // Imagen de fondo
    public TextMeshProUGUI introText;      // Texto
    public GameObject barsParent;          // Medidores

    public float initialDelay = 2f;        // Tiempo antes de que aparezca el texto
    public float textFadeInDuration = 1f;  // Duración del fade in del texto
    public float textStayDuration = 2f;    // Tiempo que el texto permanece en pantalla
    public float textFadeOutDuration = 1f; // Duración del fade out del texto
    public float finalPause = 1f;          // Pausa final antes del fade out del fondo
    public float backgroundFadeOutDuration = 2f; // Duración del fade out del fondo

    void Start()
    {
        StartCoroutine(IntroSequenceCoroutine());
    }

    IEnumerator IntroSequenceCoroutine()
    {
        // 1. Esperar el tiempo inicial antes de mostrar el texto
        yield return new WaitForSeconds(initialDelay);

        // 2. Fade in del texto
        yield return StartCoroutine(FadeText(introText, 0f, 1f, textFadeInDuration));

        // 3. Mantener el texto en pantalla
        yield return new WaitForSeconds(textStayDuration);

        // 4. Fade out del texto
        yield return StartCoroutine(FadeText(introText, 1f, 0f, textFadeOutDuration));

        // 5. Espera antes de hacer el fade out del fondo
        yield return new WaitForSeconds(finalPause);

        // 6. Fade out del fondo
        yield return StartCoroutine(FadeImage(backgroundImage, 1f, 0f, backgroundFadeOutDuration));

        // 7. Activar medidores
        //barsParent.SetActive(true);
    }

    IEnumerator FadeText(TextMeshProUGUI text, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = text.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        text.color = new Color(color.r, color.g, color.b, endAlpha);
    }

    IEnumerator FadeImage(Image image, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = image.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            image.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        image.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
