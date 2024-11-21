using UnityEngine;

public class MouseActivator : MonoBehaviour
{
    private bool activo = true;

    // Este método se llamará cuando el jugador choque con el cubo
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador (o el objeto que se espera) ha colisionado con el cubo
        if (collision.gameObject.CompareTag("Player"))
        {
            if (activo)
            {
                // Activa la visibilidad del ratón y desbloquea el cursor
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;  // Libera el ratón

                // Habilita la interacción con la UI (si no está habilitada)
                // Esto normalmente se maneja con el sistema de eventos de la UI, por lo que solo necesitas mostrar el ratón

                activo = !activo;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;  // Libera el ratón
                activo = !activo;

            }
        }
    }
}
