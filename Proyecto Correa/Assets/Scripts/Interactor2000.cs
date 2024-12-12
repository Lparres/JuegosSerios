using UnityEngine;

public class Interactor2000 : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _maxInteractionDistance = 3f; // Distancia máxima para interactuar
    [SerializeField] private Transform _player;
    private GameObject _hitObject;
    private GameObject _npc;
    private bool _interacting;
    [SerializeField] private LayerMask _layer;

    public void Interact()
    {
        // Crear un rayo desde la posición del ratón en pantalla
        if (Camera.main != null) _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Realizar el raycast
        if (!GameManager.Instance.OnDialogue && Physics.Raycast(_ray, out _hit, 200, _layer))
        {                    
            Debug.Log("RAYCAST");
            _hitObject = _hit.collider.gameObject;

            // Calcular la distancia al objeto impactado
            float distanceToObject = Vector3.Distance(_player.position, _hit.point);

            // Comprobar si está dentro del rango de interacción
            if (distanceToObject <= _maxInteractionDistance)  // && !hitObject.CompareTag("EntradaSitios"
            {
                Debug.Log("INTERACT DISTANCE: " + distanceToObject + " " + _hitObject);
                // --- GUION ---
                if (_hitObject.TryGetComponent<NPC>(out NPC n))
                {
                    n.StopMovement();
                }
                // --- GUION ---
                if (_hitObject.TryGetComponent<Guion>(out Guion g))
                {
                    _npc = _hitObject;
                    GameManager.Instance.OnDialogue = true;
                    GameManager.Instance.GetPlayer().GetComponent<FirstPersonController>().enabled = false;
                    g.NextLine();
                }
                // --- PUERTA ---
                if (_hitObject.TryGetComponent<DoorController>(out DoorController dc))
                {
                    Debug.Log("DOOR");
                    dc.ToggleDoor();
                }
                // --- PUERTA CORREDERA ---
                else if (_hitObject.TryGetComponent<SlidingDoor>(out SlidingDoor sd))
                {
                    Debug.Log("SLIDING DOOR");
                    sd.ToggleDoor();
                }
            }
            

            // --- MINIJUEGO COMIDA ---
            /*else if (_hit.collider.gameObject.GetComponent<FoodGame>() != null)
            {
                GameManager.Instance.ChangeScene("MinijuegoComida");
            }*/
        }
        else if (GameManager.Instance.OnDialogue)
        {
            if(_npc.TryGetComponent<Guion>(out Guion g))
                g.NextLine();
        }
    }
}
