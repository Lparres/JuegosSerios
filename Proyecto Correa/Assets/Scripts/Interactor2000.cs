using UnityEngine;

public class Interactor2000 : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _maxInteractionDistance = 3f; // Distancia máxima para interactuar
    [SerializeField] private Transform _player;

    public void Interact()
    {
        // Crear un rayo desde la posición del ratón en pantalla
        if (Camera.main != null) _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Realizar el raycast
        if (Physics.Raycast(_ray, out _hit, 200))
        {                                                                                   
            GameObject hitObject = _hit.collider.gameObject;

            // Calcular la distancia al objeto impactado
            float distanceToObject = Vector3.Distance(_player.position, _hit.point);

            // Comprobar si está dentro del rango de interacción
            if (distanceToObject <= _maxInteractionDistance)  // && !hitObject.CompareTag("EntradaSitios"
            {
                // --- GUION ---
                if (hitObject.TryGetComponent<Guion>(out Guion g))
                {
                    g.NextLine();
                }
                // --- PUERTA ---
                else if (hitObject.TryGetComponent<DoorController>(out DoorController dc))
                {
                    dc.ToggleDoor();
                }
            }

            // --- MINIJUEGO COMIDA ---
            /*else if (_hit.collider.gameObject.GetComponent<FoodGame>() != null)
            {
                GameManager.Instance.ChangeScene("MinijuegoComida");
            }*/
        }
    }
}
