using UnityEngine;

public class WalkingGame : MonoBehaviour
{
    private BoxCollider _col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _col = GetComponent<BoxCollider>();
        GameManager.Instance.SetWalkGame(_col);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<InputManager>() != null)
        {
            GameManager.Instance.ChangeScene("MinijuegoPaseo");
        }
    }
}
