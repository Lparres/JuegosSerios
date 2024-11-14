
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor2000 : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log("HIT");
                if (_hit.collider.gameObject.GetComponent<Guion>() != null)
                {
                    Debug.Log("Hay guion");
                    _hit.collider.gameObject.GetComponent<Guion>().NextLine();
                }
            }
        }
    }
}
