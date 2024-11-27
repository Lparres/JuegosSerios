using UnityEngine;

public class BottleDrinking : MonoBehaviour
{
    [SerializeField] private GameObject bottleContent;
    [SerializeField] private float drinkingSpeed = 0.05f;
    [SerializeField] private float scaleThreshold = 0.05f;

    private float timer = 0f;
    private bool isDrinking = true;

    void Update()
    {
        if (isDrinking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Drink();
            }

            // Comprobación Final
            if (bottleContent.transform.localScale.y <= scaleThreshold)
            {
                FinishDrinking();
            }
        }
    }

    void Drink()
    {
        // Reduce la escala en el eje Y
        Vector3 newScale = bottleContent.transform.localScale;
        newScale.y -= drinkingSpeed;
        bottleContent.transform.localScale = newScale;

        // Opcional: Ajusta la posición
        Vector3 newPosition = bottleContent.transform.position;
        newPosition.y -= drinkingSpeed / 2;
        bottleContent.transform.position = newPosition;

        timer += Time.deltaTime;
    }

    void FinishDrinking()
    {
        isDrinking = false;
        Debug.Log(timer + " segs");
        //GameManager.Instance.ChangeScene("Acto1");
    }
}
