using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    // Referencias a las imágenes de las tres barras
    [SerializeField] private Image _hungerBarImage;
    [SerializeField] private Image _entertainmentBarImage;
    [SerializeField] private Image _walkBarImage;

    // Máximos valores para cada medidor
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _maxEntertainment = 100f;
    [SerializeField] private float _maxWalk = 100f;

    // Valores actuales de cada medidor
    private float _currentHunger;
    private float _currentEntertainment;
    private float _currentWalk;

    void Start()
    {
        // Inicializa cada medidor al máximo valor
        _currentHunger = _maxHunger;
        _currentEntertainment = _maxEntertainment;
        _currentWalk = _maxWalk;

        UpdateAllBars();
    }

    public void UpdateHunger(float amount)
    {
        _currentHunger = Mathf.Clamp(_currentHunger + amount, 0, _maxHunger);
        UpdateHungerBar();
    }

    public void UpdateEntertainment(float amount)
    {
        _currentEntertainment = Mathf.Clamp(_currentEntertainment + amount, 0, _maxEntertainment);
        UpdateEntertainmentBar();
    }

    public void UpdateWalk(float amount)
    {
        _currentWalk = Mathf.Clamp(_currentWalk + amount, 0, _maxWalk);
        UpdateWalkBar();
    }

    // Métodos para actualizar cada barra individualmente
    private void UpdateHungerBar()
    {
        _hungerBarImage.fillAmount = _currentHunger / _maxHunger;
    }

    private void UpdateEntertainmentBar()
    {
        _entertainmentBarImage.fillAmount = _currentEntertainment / _maxEntertainment;
    }

    private void UpdateWalkBar()
    {
        _walkBarImage.fillAmount = _currentWalk / _maxWalk;
    }

    // Método opcional para actualizar todas las barras al iniciar el juego
    private void UpdateAllBars()
    {
        UpdateHungerBar();
        UpdateEntertainmentBar();
        UpdateWalkBar();
    }

    public void ResetAllBars()
    {
        _currentHunger = _maxHunger;
        
        UpdateAllBars();
    }
}

