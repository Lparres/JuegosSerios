using System.Collections;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 openPositionOffset; // Desplazamiento desde la posición original para abrir la puerta
    public float speed = 2.0f;         // Velocidad de movimiento

    private Vector3 closedPosition;  // Posición inicial de la puerta
    private Vector3 openPosition;    // Posición de apertura
    private bool isOpen = false;     // Estado de la puerta

    void Start()
    {
        // Guardar la posición original de la puerta
        closedPosition = transform.position;
        openPosition = closedPosition + openPositionOffset;
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        StopAllCoroutines(); // Detener cualquier movimiento previo
        StartCoroutine(MoveDoor(isOpen ? openPosition : closedPosition));
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }
}
