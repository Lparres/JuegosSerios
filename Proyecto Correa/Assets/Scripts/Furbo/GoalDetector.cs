using UnityEngine;
using System.Collections;
using TMPro;

public class GoalDetector : MonoBehaviour
{
    private NarrativeManager _narrative;

    [SerializeField] private int score = 0;
    [SerializeField] private int goalsToWin = 3;

    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject ball_;

    private Vector3 initialPlayerPosition;
    private Vector3 initialBallPosition;

    [SerializeField] private float gameTime = 30f; // Duraci�n del minijuego en segundos
    [SerializeField] private TextMeshProUGUI timerText; // Referencia al texto del temporizador en la UI

    private bool isGameRunning = true;

    void Start()
    {
        timerText = GameManager.Instance.UI._furbo.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        _narrative = NarrativeManager.Instance;

        // Guardar las posiciones iniciales
        initialPlayerPosition = player_.transform.position;
        initialBallPosition = ball_.transform.position;

        GameManager.Instance.UI._furbo.SetActive(true);

        // Iniciar la corrutina del temporizador
        StartCoroutine(GameTimer());
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isGameRunning) return;

        if (other.CompareTag("Ball")) // Comprueba si el objeto es la pelota
        {
            score++;
            GameManager.Instance.UpdateEntertainment(4);
            GameManager.Instance.UI._furbo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString() + " pts";

            // Iniciar la corrutina para pausar antes de resetear
            StartCoroutine(ResetAfterDelay());

            if (score >= goalsToWin)
            {
                EndMinigame();
            }
        }
    }

    private IEnumerator ResetAfterDelay()
    {
        // Esperar 1 segundo
        yield return new WaitForSeconds(1f);

        // Resetear posiciones
        player_.transform.position = initialPlayerPosition;
        ball_.transform.position = initialBallPosition;

        // Resetear velocidades
        Rigidbody ballRb = ball_.GetComponent<Rigidbody>();
        ballRb.linearVelocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        Rigidbody playerRb = player_.GetComponent<Rigidbody>();
        playerRb.linearVelocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }

    private IEnumerator GameTimer()
    {
        while (gameTime > 0)
        {
            if (!isGameRunning) yield break;

            // Reducir el tiempo
            gameTime -= Time.deltaTime;

            // Actualizar la UI del temporizador
            timerText.text = "Tiempo: " + Mathf.CeilToInt(gameTime).ToString();

            yield return null; // Esperar al siguiente frame
        }

        EndMinigame();
    }

    private void EndMinigame()
    {
        isGameRunning = false;

        _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);

        GameManager.Instance.UI._furbo.SetActive(false);
    }
}
