using UnityEngine;

public class ActivadorDeParticulas : MonoBehaviour
{
    [SerializeField]
    private bool activo = false; // Variable que controla si se generan partículas o no

    [SerializeField]
    private GameObject prefabDeParticulas; // Prefab del sistema de partículas a instanciar

    private GameObject particulasInstanciadas; // Referencia al sistema de partículas instanciado

    void Update()
    {
        // Controlar la activación y desactivación del sistema de partículas
        if (activo && particulasInstanciadas == null)
        {
            InstanciarParticulas();
        }
        else if (!activo && particulasInstanciadas != null)
        {
            DestruirParticulas();
        }
    }

    // Método para instanciar el sistema de partículas
    private void InstanciarParticulas()
    {
        if (prefabDeParticulas == null)
        {
            Debug.LogError("No se asignó un prefab de partículas en el Inspector.");
            return;
        }

        // Instanciar el prefab con una rotación orientada hacia arriba
        particulasInstanciadas = Instantiate(prefabDeParticulas, transform.position, Quaternion.identity);

        // Asegurar que esté correctamente orientado (rotación vertical)
        particulasInstanciadas.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Opcional: Hacer que las partículas sigan al GameObject padre
        particulasInstanciadas.transform.parent = transform;
    }


    // Método para destruir el sistema de partículas
    private void DestruirParticulas()
    {
        if (particulasInstanciadas != null)
        {
            Destroy(particulasInstanciadas);
            particulasInstanciadas = null;
        }
    }

    // Métodos públicos para modificar y obtener el estado
    public void SetActivo(bool estado)
    {
        activo = estado;
    }

    public bool GetActivo()
    {
        return activo;
    }
}
