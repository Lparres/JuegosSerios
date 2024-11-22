
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactor2000 : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _maxInteractionDistance = 3f; // Distancia m�xima para interactuar
    [SerializeField] private Transform _player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un rayo desde la posici�n del rat�n en pantalla
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Realizar el raycast
            if (Physics.Raycast(_ray, out _hit, 200))
            {
                GameObject hitObject = _hit.collider.gameObject;

                // Calcular la distancia al objeto impactado
                float distanceToObject = Vector3.Distance(_player.position, _hit.point);

                // Comprobar si est� dentro del rango de interacci�n
                if (distanceToObject <= _maxInteractionDistance)
                {
                    // --- GUION ---
                    if (hitObject.GetComponent<Guion>() != null)
                    {
                        hitObject.GetComponent<Guion>().LittleTalks();
                    }
                    // --- PUERTA ---
                    else if (hitObject.GetComponent<DoorController>() != null)
                    {
                        hitObject.GetComponent<DoorController>().ToggleDoor();
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
}
