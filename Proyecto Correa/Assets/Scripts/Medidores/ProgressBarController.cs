using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    // Referencias a las imágenes de las tres barras
    public Image hungerBarImage;
    public Image entertainmentBarImage;
    public Image walkBarImage;

    // Máximos valores para cada medidor
    public float maxHunger = 100f;
    public float maxEntertainment = 100f;
    public float maxWalk = 100f;

    // Valores actuales de cada medidor
    private float currentHunger;
    private float currentEntertainment;
    private float currentWalk;

    void Start()
    {
        // Inicializa cada medidor al máximo valor
        currentHunger = maxHunger;
        currentEntertainment = maxEntertainment;
        currentWalk = maxWalk;

        UpdateAllBars();
    }

    public void UpdateHunger(float amount)
    {
        currentHunger = Mathf.Clamp(currentHunger + amount, 0, maxHunger);
        UpdateHungerBar();
    }

    public void UpdateEntertainment(float amount)
    {
        currentEntertainment = Mathf.Clamp(currentEntertainment + amount, 0, maxEntertainment);
        UpdateEntertainmentBar();
    }

    public void UpdateWalk(float amount)
    {
        currentWalk = Mathf.Clamp(currentWalk + amount, 0, maxWalk);
        UpdateWalkBar();
    }

    // Métodos para actualizar cada barra individualmente
    void UpdateHungerBar()
    {
        hungerBarImage.fillAmount = currentHunger / maxHunger;
    }

    void UpdateEntertainmentBar()
    {
        entertainmentBarImage.fillAmount = currentEntertainment / maxEntertainment;
    }

    void UpdateWalkBar()
    {
        walkBarImage.fillAmount = currentWalk / maxWalk;
    }

    // Método opcional para actualizar todas las barras al iniciar el juego
    void UpdateAllBars()
    {
        UpdateHungerBar();
        UpdateEntertainmentBar();
        UpdateWalkBar();
    }
}

