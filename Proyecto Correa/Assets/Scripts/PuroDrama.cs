using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuroDrama : MonoBehaviour
{
    [SerializeField] FirstPersonController controller;

    [SerializeField] Volume volume;
    private Vignette vignette;

    [SerializeField] float speedReduction;
    [SerializeField] float vignetteIntensity;
    [SerializeField] float vignetteSmoothness;

    [SerializeField] float startFadeIn;
    [SerializeField] float fadeInSpeed;
    private Image fade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volume.profile.TryGet(out vignette);
        StartCoroutine(FadeInCoroutine());

        fade = GameManager.Instance.transform.GetChild(0).GetChild(1).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.walkSpeed > 0)
            controller.walkSpeed -= Time.deltaTime * speedReduction;

        vignette.intensity.value += Time.deltaTime * vignetteIntensity;
        vignette.smoothness.value += Time.deltaTime * vignetteSmoothness;
    }

    IEnumerator FadeInCoroutine() {
        yield return new WaitForSeconds(startFadeIn);
        fade.gameObject.SetActive(true);
        fade.color = new Color(0, 0, 0, 0);

        while(fade.color.a < 1) {
            fade.color += new Color(0, 0, 0, fadeInSpeed) * Time.deltaTime;
            yield return new WaitForSeconds(0);
        }

        yield return new WaitForSeconds(2);

        GameManager.Instance.deathPosition = transform.position;
        
        SceneManager.LoadScene(10);
    }

}
