using Unity.VisualScripting;
using UnityEngine;

public class EntertainmentGame : MonoBehaviour
{
    private ActivadorDeParticulas _particles;
    private BoxCollider _col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _particles = GetComponent<ActivadorDeParticulas>();
        _col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.ChangeScene("MinijuegoEntretenimiento");
    }

    public void SetState(bool state)
    {
        _particles.enabled = state;
        _col.enabled = state;
        enabled = state;
    }
}
