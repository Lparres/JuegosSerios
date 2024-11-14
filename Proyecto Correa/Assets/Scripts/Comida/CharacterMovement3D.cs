using UnityEngine;

public class CharacterMovement3D : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Movimiento oscilante en 3D
        float xOffset = Mathf.Sin(Time.time * moveSpeed) * 0.5f;
        float yOffset = Mathf.Cos(Time.time * moveSpeed) * 0.3f;
        transform.position = initialPosition + new Vector3(xOffset, yOffset, 0);
    }
}
