using UnityEngine;
using UnityEngine.UI;

public class BottleController3D : MonoBehaviour
{
    public Slider angleSlider;
    public Transform bottle;
    public ParticleSystem milkSpillEffect; // Partículas del derrame de leche
    public Renderer bottleRenderer; // El Renderer del biberón para cambiar su color

    public float minCorrectAngle = 15f;
    public float maxCorrectAngle = 30f;
    private Color correctColor = Color.green;
    private Color incorrectColor = Color.red;

    void Start()
    {
        // Inicializa el color del biberón en incorrecto
        bottleRenderer.material.color = incorrectColor;
    }

    void Update()
    {
        // Rotación del biberón en el eje X
        float angle = Mathf.Lerp(-45, 45, angleSlider.value);
        bottle.localRotation = Quaternion.Euler(angle, 0, 0);

        // Verificar si el ángulo está dentro del rango correcto
        if (angle >= minCorrectAngle && angle <= maxCorrectAngle)
        {
            milkSpillEffect.Stop(); // Detiene el derrame si el ángulo es correcto
            bottleRenderer.material.color = correctColor; // Cambia el color a verde
        }
        else
        {
            if (!milkSpillEffect.isPlaying)
                milkSpillEffect.Play(); // Activa el derrame si el ángulo es incorrecto

            bottleRenderer.material.color = incorrectColor; // Cambia el color a rojo
        }
    }
}
