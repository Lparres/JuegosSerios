using UnityEngine;

public class GeneradorNivel : MonoBehaviour
{
    public GameObject prefabSuelo;
    public GameObject prefabObstaculo;
    public Transform jugador;
    public float distanciaDeGeneracion = 30f;
    public float separacionEntreSegmentos = 30f;
    private float ultimaPosicionGenerada = 0f;

    void Update()
    {
        if (jugador.position.z + distanciaDeGeneracion > ultimaPosicionGenerada)
        {
            GenerarSegmento(ultimaPosicionGenerada);
            ultimaPosicionGenerada += separacionEntreSegmentos;
        }
    }

    void GenerarSegmento(float posicionZ)
    {
        GameObject aux;
        aux = Instantiate(prefabSuelo, new Vector3(0, 0, posicionZ), Quaternion.identity);
        aux.transform.Rotate(new Vector3(1, 0, 0), -90);
        aux.transform.Rotate(new Vector3(0, 0, 1), 90);

        if (Random.value > 0.5f)
        {
            float posicionXObstaculo = Random.Range(-2f, 2f);
            aux = Instantiate(prefabObstaculo, new Vector3(posicionXObstaculo, 1f, posicionZ), Quaternion.identity);
            aux.transform.position = new Vector3(6, 0, posicionZ);

        }
    }
}
