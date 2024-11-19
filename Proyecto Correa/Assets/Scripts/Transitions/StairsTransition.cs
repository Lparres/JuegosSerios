using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StairsTransition : MonoBehaviour
{
    public Image fadeImage; // Imagen usada para el fade
    public float fadeDuration = 1f; // Duración del fade

    public Transform objetivePos;



    private bool isFading = false;

    private void OnTriggerEnter(Collider other)
    {
        ChangePosition();
    }

    /// <summary>
    /// Llamar a este método para cambiar de escena con un fade out y fade in.
    /// </summary>
    public void ChangePosition()
    {
        if (!isFading)
        {
            StartCoroutine(FadeOutAndChangePosition());
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

    private IEnumerator FadeOutAndChangePosition()
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
        GameManager.Instance.GetPlayer().GetComponent<Transform>().position = objetivePos.position;

        // Comenzar el fade in de la nueva escena
        StartCoroutine(FadeIn());
    }
}
