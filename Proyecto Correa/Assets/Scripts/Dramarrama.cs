using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dramarrama : MonoBehaviour
{
    [SerializeField] GameObject cachorroPrefab;
    [SerializeField] Camera cam;
    
    [SerializeField] float cameraCinematicSpeed;

    [SerializeField] float fadeInSpeed;
    private Image fade;
    void Start()
    {
        Instantiate(cachorroPrefab, GameManager.Instance.deathPosition, Quaternion.identity);
        cam.transform.position = GameManager.Instance.deathPosition + Vector3.up * 0.1f;

        fade = GameManager.Instance.transform.GetChild(0).GetChild(1).GetComponent<Image>();
        fade.gameObject.SetActive(false);

        StartCoroutine(CinematicCoroutine());


    }

    // Update is called once per frame
    void Update()
    {
            
    }

    IEnumerator CinematicCoroutine() {
        fade.gameObject.SetActive(true);
        fade.color = new Color(0, 0, 0, 1);

        while (cam.transform.position.y < 10) {
            cam.transform.position += Vector3.up * cameraCinematicSpeed * Time.deltaTime;
            if(fade.color.a > 0 && cam.transform.position.y < 5)
                fade.color -= new Color(0, 0, 0, 0.1f) * Time.deltaTime;
            yield return new WaitForSeconds(0);
        }

        StartCoroutine(FadeInCoroutine());

    }

    IEnumerator FadeInCoroutine() {
        fade.gameObject.SetActive(true);
        fade.color = new Color(0, 0, 0, 0);

        while (fade.color.a < 1) {
            fade.color += new Color(0, 0, 0, fadeInSpeed) * Time.deltaTime;
            yield return new WaitForSeconds(0);
        }

        yield return new WaitForSeconds(2);

        fade.gameObject.SetActive(false);

        SceneManager.LoadScene(0);


    }
}
