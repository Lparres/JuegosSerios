
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor2000 : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    public float maxInteractionDistance = 3f; // Distancia máxima para interactuar
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un rayo desde la posición del ratón en pantalla
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Realizar el raycast
            if (Physics.Raycast(_ray, out _hit, 200))
            {
                GameObject hitObject = _hit.collider.gameObject;

                // Calcular la distancia al objeto impactado
                float distanceToObject = Vector3.Distance(player.position, _hit.point);

                // Comprobar si está dentro del rango de interacción
                if (distanceToObject <= maxInteractionDistance)
                {
                    // --- GUION ---
                    if (hitObject.GetComponent<Guion>() != null)
                    {
                        hitObject.GetComponent<Guion>().NextLine();
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
