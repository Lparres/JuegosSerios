using UnityEngine;

public class PlayerControllerWalk : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de avance del jugador
    public float fuerzaDeSalto = 5f; // Fuerza con la que el jugador salta
    private bool enElSuelo = true; // Verifica si el jugador está en el suelo

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
            enElSuelo = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }
}
