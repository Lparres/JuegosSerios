using UnityEngine;

public class ActivadorDeParticulas : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabDeParticulas; // Prefab del sistema de part�culas a instanciar
    private GameObject particulasInstanciadas; // Referencia al sistema de part�culas instanciado

    void Update()
    {
        // Controlar la activaci�n y desactivaci�n del sistema de part�culas
        if (particulasInstanciadas == null)
        {
            InstanciarParticulas();
        }
        else if (particulasInstanciadas != null)
        {
            DestruirParticulas();
        }
    }

    // M�todo para instanciar el sistema de part�culas
    private void InstanciarParticulas()
    {
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
}
