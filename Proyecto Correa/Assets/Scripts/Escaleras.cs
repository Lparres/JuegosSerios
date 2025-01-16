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
            if (NarrativeManager.Instance.Act == 1) GameManager.Instance.ChangeScene("Acto2");
            if (NarrativeManager.Instance.Act == 2) GameManager.Instance.ChangeScene("Acto3");
            GameManager.Instance.GetNarrativeManager().NextAct();
        }
    }
}
