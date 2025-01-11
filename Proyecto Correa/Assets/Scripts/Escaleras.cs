using UnityEngine;

public class Escaleras : MonoBehaviour
{
    //private ActivadorDeParticulas _particles;
    private BoxCollider _col;

    private void Start()
    {
        _col = GetComponent<BoxCollider>();
        GameManager.Instance.SetStairs(_col);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<FirstPersonController>() != null)
        {
            GameManager.Instance.ChangeScene("Acto2");
            GameManager.Instance.GetNarrativeManager().NextAct();
        }
    }
}
