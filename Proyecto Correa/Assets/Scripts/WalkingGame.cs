using UnityEngine;

public class WalkingGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.ChangeScene("MinijuegoPaseo");
    }
}