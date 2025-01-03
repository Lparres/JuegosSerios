using UnityEngine;

public class BottleMinigame3D : MonoBehaviour
{
    public Renderer bottleRenderer; // Renderer del biber�n para cambiar el material/color
    public Color correctColor = Color.green; // Color para el ritmo correcto
    public Color incorrectColor = Color.red; // Color para el ritmo incorrecto
    public Color defaultColor = Color.white; // Color por defecto del biber�n

    public float targetInterval = 0.5f; // Tiempo ideal entre pulsaciones (en segundos)
    public float tolerance = 0.1f; // Tolerancia en el ritmo
    public int successfulPressesRequired = 10; // Pulsaciones correctas necesarias para ganar

    private float lastPressTime = 0f; // Tiempo de la �ltima pulsaci�n
    private int successfulPressCount = 0; // N�mero de pulsaciones correctas
    private bool isGameActive = true; // Estado del minijuego

    private Material bottleMaterial; // Material del biber�n para cambiar el color din�micamente

    void Start()
    {
        // Obtener el material inicial del Renderer del biber�n
        bottleMaterial = bottleRenderer.material;
        bottleMaterial.color = defaultColor;
    }

    void Update()
    {
        if (!isGameActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time; // Tiempo actual
            float timeDifference = currentTime - lastPressTime; // Diferencia entre pulsaciones

            // Verificar si la pulsaci�n est� dentro del ritmo correcto
            if (timeDifference >= targetInterval - tolerance && timeDifference <= targetInterval + tolerance)
            {
                successfulPressCount++;
                bottleMaterial.color = correctColor; // Cambiar a color verde
            }
            else
            {
                bottleMaterial.color = incorrectColor; // Cambiar a color rojo
            }

            lastPressTime = currentTime; // Actualizar el tiempo de la �ltima pulsaci�n

            // Verificar si el jugador ha ganado
            if (successfulPressCount >= successfulPressesRequired)
            {
                EndGame(true);
            }
        }

        // Si no se presiona espacio en el tiempo esperado, mostrar inactividad
        if (Time.time - lastPressTime > targetInterval + tolerance)
        {
            bottleMaterial.color = defaultColor; // Restablecer al color por defecto
        }
    }

    void EndGame(bool success)
    {
        isGameActive = false;

        if (success)
        {
            Debug.Log("�Ganaste el minijuego!");
            bottleMaterial.color = correctColor; // Indicar �xito
        }
        else
        {
            Debug.Log("Perdiste el minijuego.");
            bottleMaterial.color = incorrectColor; // Indicar fallo
        }

        // Aqu� puedes agregar l�gica adicional, como activar un evento o cambiar de escena
    }
}
