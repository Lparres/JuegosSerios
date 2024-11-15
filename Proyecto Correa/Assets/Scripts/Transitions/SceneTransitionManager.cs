using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public Image fadeImage; // Imagen usada para el fade
    public float fadeDuration = 1f; // Duraci�n del fade

    private bool isFading = false;

    void Start()
    {
        // Comenzar con un fade in
        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// Llamar a este m�todo para cambiar de escena con un fade out y fade in.
    /// </summary>
    /// <param name="sceneName">El nombre de la escena a cargar</param>
    public void ChangeScene(string sceneName)
    {
        if (!isFading)
        {
            StartCoroutine(FadeOutAndChangeScene(sceneName));
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;
        fadeImage.gameObject.SetActive(false);
        isFading = false;
    }

    private IEnumerator FadeOutAndChangeScene(string sceneName)
    {
        isFading = true;
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1;
        fadeImage.color = color;

        // Cambiar de escena
        GameManager.Instance.ChangeScene(sceneName);

        // Comenzar el fade in de la nueva escena
        StartCoroutine(FadeIn());
    }
}