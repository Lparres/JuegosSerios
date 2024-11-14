using UnityEngine;

public class MouseActivator : MonoBehaviour
{
    // Este m�todo se llamar� cuando el jugador choque con el cubo
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador (o el objeto que se espera) ha colisionado con el cubo
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activa la visibilidad del rat�n y desbloquea el cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;  // Libera el rat�n

            // Habilita la interacci�n con la UI (si no est� habilitada)
            // Esto normalmente se maneja con el sistema de eventos de la UI, por lo que solo necesitas mostrar el rat�n
        }
    }
}
