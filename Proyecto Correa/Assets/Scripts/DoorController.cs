using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorHinge; // Punto de rotación de la puerta
    public float openAngle = 90f; // Ángulo al que la puerta se abre
    public float openingSpeed = 2f; // Velocidad de apertura

    private bool isOpen = false; // Estado de la puerta
    private Quaternion closedRotation; // Rotación inicial (puerta cerrada)
    private Quaternion openRotation; // Rotación final (puerta abierta)

    void Start()
    {
        if (doorHinge == null)
        {
            doorHinge = transform; // Si no se define un hinge, se toma el propio objeto
        }

        // Guardar las rotaciones inicial y final
        closedRotation = doorHinge.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        // Animar la puerta hacia el estado objetivo
        doorHinge.rotation = Quaternion.Lerp(doorHinge.rotation, isOpen ? openRotation : closedRotation, Time.deltaTime * openingSpeed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen; // Alternar el estado de la puerta
    }
}
