using UnityEngine;

public class QuitadorDeMedidores : MonoBehaviour
{
    [SerializeField] private GameObject medidores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        medidores = GameManager.Instance.UI.medidores;
        medidores.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
