using UnityEngine;

public class ActivadorDeParticulas : MonoBehaviour
{
    [SerializeField]
    private bool activo = false; // Variable que controla si se generan part�culas o no

    [SerializeField]
    private GameObject prefabDeParticulas; // Prefab del sistema de part�culas a instanciar

    private GameObject particulasInstanciadas; // Referencia al sistema de part�culas instanciado

    void Update()
    {
        // Controlar la activaci�n y desactivaci�n del sistema de part�culas
        if (activo && particulasInstanciadas == null)
        {
            InstanciarParticulas();
        }
        else if (!activo && particulasInstanciadas != null)
        {
            DestruirParticulas();
        }
    }

    // M�todo para instanciar el sistema de part�culas
    private void InstanciarParticulas()
    {
        if (prefabDeParticulas == null)
        {
            Debug.LogError("No se asign� un prefab de part�culas en el Inspector.");
            return;
        }

        // Instanciar el prefab con una rotaci�n orientada hacia arriba
        particulasInstanciadas = Instantiate(prefabDeParticulas, transform.position, Quaternion.identity);

        // Asegurar que est� correctamente orientado (rotaci�n vertical)
        particulasInstanciadas.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Opcional: Hacer que las part�culas sigan al GameObject padre
        particulasInstanciadas.transform.parent = transform;
    }


    // M�todo para destruir el sistema de part�culas
    private void DestruirParticulas()
    {
        if (particulasInstanciadas != null)
        {
            Destroy(particulasInstanciadas);
            particulasInstanciadas = null;
        }
    }

    // M�todos p�blicos para modificar y obtener el estado
    public void SetActivo(bool estado)
    {
        activo = estado;
    }

    public bool GetActivo()
    {
        return activo;
    }
}
