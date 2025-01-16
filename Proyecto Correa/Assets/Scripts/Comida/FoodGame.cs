using UnityEngine;

public class FoodGame : MonoBehaviour
{
    private BoxCollider _col;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _col = GetComponent<BoxCollider>();
        GameManager.Instance.SetFoodGame(_col);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<InputManager>() != null)
            GameManager.Instance.ChangeScene("Biberón");
    }
}
