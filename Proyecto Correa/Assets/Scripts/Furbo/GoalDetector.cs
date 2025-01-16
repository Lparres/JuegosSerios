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

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI pointText;

    private bool isGameRunning = true;
    private float gameTime;

    void Start()
    {
        timerText = GameManager.Instance.UI._furbo.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        pointText = GameManager.Instance.UI._furbo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();

        timerText.text = "Fin: 30";
        pointText.text = "0 pts";

        _narrative = NarrativeManager.Instance;

        initialPlayerPosition = player_.transform.position;
        initialBallPosition = ball_.transform.position;

        gameTime = GetGameTimeForCurrentLevel();
        GameManager.Instance.UI._furbo.SetActive(true);

        StartCoroutine(GameTimer());
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isGameRunning) return;

        if (other.CompareTag("Ball"))
        {
            score++;
            GameManager.Instance.UpdateEntertainment(4);
            GameManager.Instance.UI._furbo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString() + " pts";
        
            StartCoroutine(ResetAfterDelay());
        }
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(1f);

        player_.transform.position = initialPlayerPosition;
        ball_.transform.position = GetRandomBallPosition();

        Rigidbody ballRb = ball_.GetComponent<Rigidbody>();
        ballRb.linearVelocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;

        Rigidbody playerRb = player_.GetComponent<Rigidbody>();
        playerRb.linearVelocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetRandomBallPosition()
    {
        float randomOffsetZ = Random.Range(-10f, 10f);
        return new Vector3(initialBallPosition.x, initialBallPosition.y, initialBallPosition.z + randomOffsetZ);
    }

    private IEnumerator GameTimer()
    {
        while (gameTime > 0)
        {
            if (!isGameRunning) yield break;

            gameTime -= Time.deltaTime;
            timerText.text = "Fin: " + Mathf.CeilToInt(gameTime).ToString();

            yield return null;
        }

        EndMinigame();
    }

    private void EndMinigame()
    {
        isGameRunning = false;

        _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);

        GameManager.Instance.UI._furbo.SetActive(false);
    }

    private float GetGameTimeForCurrentLevel()
    {
        int currentLevel = _narrative.Act;

        switch (currentLevel)
        {
            case 1:
                return 59;
            case 2:
                return 25f;
            case 3:
                return 15f;
            case 4:
                return 5f;
            default:
                return 30f;
        }
    }
}
