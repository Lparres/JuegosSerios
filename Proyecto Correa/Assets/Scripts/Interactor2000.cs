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
        if (Camera.main != null) _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!GameManager.Instance.OnDialogue && Physics.Raycast(_ray, out _hit, 200, _layer))
        {                    
            _hitObject = _hit.collider.gameObject;

            // Calcular la distancia al objeto
            float distanceToObject = Vector3.Distance(_player.position, _hit.point);

            // Comprobar si está dentro del rango de interacción
            if (distanceToObject <= _maxInteractionDistance)
            {
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
                    dc.ToggleDoor();
                }
                // --- PUERTA CORREDERA ---
                else if (_hitObject.TryGetComponent<SlidingDoor>(out SlidingDoor sd))
                {
                    sd.ToggleDoor();
                }
            }
        }
        else if (GameManager.Instance.OnDialogue)
        {
            if(_npc.TryGetComponent<Guion>(out Guion g))
                g.NextLine();
        }
    }
}
