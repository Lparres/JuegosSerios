using UnityEngine;

public class WalkingManager : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (GameManager.Instance.GetNarrativeManager().Act <= 2)
        {
            player.GetComponent<PlayerControllerWalk>().velocidad = 4;
            player.GetComponent<PlayerControllerWalk>().fuerzaDeSalto = 8;
        }
        else
        {
            player.GetComponent<PlayerControllerWalk>().velocidad = 7;
            player.GetComponent<PlayerControllerWalk>().fuerzaDeSalto = 7;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            byebye();
            timer = 0;
        }
    }

    void byebye()
    {
        // Implementa este método con la funcionalidad deseada
    }
}
