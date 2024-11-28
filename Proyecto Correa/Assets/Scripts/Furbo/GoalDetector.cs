using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    private NarrativeManager _narrative;

    [SerializeField] private int score = 0;
    [SerializeField] private int goalsToWin = 3;

    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject ball_;

    private Vector3 initialPlayerPosition;
    private Vector3 initialBallPosition;

    void Start()
    {
        _narrative = NarrativeManager.Instance;
        // Guardar las posiciones iniciales
        initialPlayerPosition = player_.transform.position;
        initialBallPosition = ball_.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Comprueba si el objeto es la pelota
        {
            score++;
            Debug.Log("Puntuacion: " + score);

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

            if (score >= goalsToWin)
            {
                //NarrativeManager.Instance.AdvanceAct();
                _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);
            }
        }
    }
}
