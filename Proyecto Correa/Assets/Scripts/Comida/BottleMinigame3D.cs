using UnityEngine;

public class BottleMinigame3D : MonoBehaviour
{
    public Renderer bottleRenderer; // Renderer del biberón para cambiar el material/color
    public Color correctColor = Color.green; // Color para el ritmo correcto
    public Color incorrectColor = Color.red; // Color para el ritmo incorrecto
    public Color defaultColor = Color.white; // Color por defecto del biberón

    public float targetInterval = 0.5f; // Tiempo ideal entre pulsaciones (en segundos)
    public float tolerance = 0.1f; // Tolerancia en el ritmo
    public int successfulPressesRequired = 10; // Pulsaciones correctas necesarias para ganar

    private float lastPressTime = 0f; // Tiempo de la última pulsación
    private int successfulPressCount = 0; // Número de pulsaciones correctas
    private bool isGameActive = true; // Estado del minijuego

    private Material bottleMaterial; // Material del biberón para cambiar el color dinámicamente

    void Start()
    {
        // Obtener el material inicial del Renderer del biberón
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

            // Verificar si la pulsación está dentro del ritmo correcto
            if (timeDifference >= targetInterval - tolerance && timeDifference <= targetInterval + tolerance)
            {
                successfulPressCount++;
                bottleMaterial.color = correctColor; // Cambiar a color verde
            }
            else
            {
                bottleMaterial.color = incorrectColor; // Cambiar a color rojo
            }

            lastPressTime = currentTime; // Actualizar el tiempo de la última pulsación

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
            bottleMaterial.color = correctColor; // Indicar éxito
        }
        else
        {
            bottleMaterial.color = incorrectColor; // Indicar fallo
        }

        // Aquí puedes agregar lógica adicional, como activar un evento o cambiar de escena
    }
}
