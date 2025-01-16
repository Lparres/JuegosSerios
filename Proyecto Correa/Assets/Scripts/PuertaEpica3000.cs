using UnityEngine;

public class PuertaEpica3000 : MonoBehaviour
{
    [SerializeField] private float tiempoRestante;

    private bool temporizadorActivo = true;
    void Start()
    {

    }

    void Update()
    {
        if (temporizadorActivo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                temporizadorActivo = false;

                ByebyePuerta();
            }
        }
    }

    void ByebyePuerta()
    {
        this.gameObject.SetActive(false);
    }

    // Método para reiniciar el temporizador (opcional)
    public void ReiniciarTemporizador(float nuevoTiempo)
    {
        tiempoRestante = nuevoTiempo;
        temporizadorActivo = true;
    }
}