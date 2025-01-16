using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("QUITO PASEO");
        if (GameManager.Instance.GetNarrativeManager().Act <= 2)
        {
            GameManager.Instance.UpdateWalk(-5);
        }
        else
        {
            GameManager.Instance.UpdateWalk(-15);
        }
    }
}
