using UnityEngine;

public class WalkingManager : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private GameObject player;
    private float checkInterval = 2f;
    private float nextCheckTime;

    private void Start()
    {
        if (GameManager.Instance.GetNarrativeManager().Act <= 2)
        {
            player.GetComponent<PlayerControllerWalk>().velocidad = 4;
            player.GetComponent<PlayerControllerWalk>().fuerzaDeSalto = 5;
        }
        else
        {
            player.GetComponent<PlayerControllerWalk>().velocidad = 7;
            player.GetComponent<PlayerControllerWalk>().fuerzaDeSalto = 4;
        }
        nextCheckTime = Time.time + checkInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            byebye();
            timer = 0;
        }

        if (Time.time >= nextCheckTime)
        {
            nextCheckTime += checkInterval;

            if (GameManager.Instance.GetNarrativeManager().Act <= 2)
            {
                GameManager.Instance.UpdateWalk(2);
            }
            else
            {
                GameManager.Instance.UpdateWalk(1);
            }
        }
    }

    void byebye()
    {
        GameManager.Instance.GetNarrativeManager().EventByName("MinigameEnded", "Acto" + GameManager.Instance.GetNarrativeManager().Act);
    }
}
