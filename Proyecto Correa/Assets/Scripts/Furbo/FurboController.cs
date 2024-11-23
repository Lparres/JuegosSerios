using UnityEngine;

public class FurboController : MonoBehaviour
{
    [SerializeField] private GameObject ball; // Referencia a la pelota
    [SerializeField] private float kickForce = 500f; // Fuerza del disparo
    [SerializeField] private float maxKickDistance = 2f; // Distancia máxima para poder disparar
    [SerializeField] private float liftFactor = 0.5f; // Factor para elevar la pelota

    void Update()
    {
        // Detectar la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryKickBall();
        }
    }

    private void TryKickBall()
    {
        if (ball != null)
        {
            // Calcular la distancia entre el jugador y la pelota
            float distanceToBall = Vector3.Distance(transform.position, ball.transform.position);

            if (distanceToBall <= maxKickDistance)
            {
                // Si está dentro del rango, dispara la pelota
                KickBall();
            }
            else
            {
                Debug.Log("¡Demasiado lejos para disparar!");
            }
        }
        else
        {
            Debug.LogError("No se ha asignado la pelota.");
        }
    }

    private void KickBall()
    {
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        if (ballRb != null)
        {
            // Calcular dirección del disparo con elevación
            Vector3 kickDirection = (transform.forward + Vector3.up * liftFactor).normalized;

            // Aplicar fuerza a la pelota
            ballRb.AddForce(kickDirection * kickForce);
            Debug.Log("¡Disparo realizado!");
        }
        else
        {
            Debug.LogError("La pelota no tiene un Rigidbody.");
        }
    }
}
