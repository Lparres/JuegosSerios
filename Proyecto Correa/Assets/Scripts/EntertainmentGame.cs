using System;
using Unity.VisualScripting;
using UnityEngine;

public class EntertainmentGame : MonoBehaviour
{
    //private ActivadorDeParticulas _particles;
    private BoxCollider _col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //_particles = GetComponent<ActivadorDeParticulas>();

    }

    private void Start()
    {
        _col = GetComponent<BoxCollider>();
        GameManager.Instance.SetEntertainment(_col);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<InputManager>() != null)
            GameManager.Instance.ChangeScene("MinijuegoEntretenimiento");
    }

    public void SetState(bool state)
    {
        //_particles.enabled = state;
        _col.enabled = state;
        enabled = state;
    }
}
