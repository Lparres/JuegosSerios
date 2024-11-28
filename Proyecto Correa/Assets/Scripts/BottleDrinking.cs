using System;
using UnityEngine;

public class BottleDrinking : MonoBehaviour
{
    [SerializeField] private GameObject bottleContent;
    [SerializeField] private float drinkingSpeed = 0.05f;
    [SerializeField] private float scaleThreshold = 0.05f;
    
    private NarrativeManager _narrative;

    private float timer = 0f;
    private bool isDrinking = true;

    private void Start()
    {
        _narrative = NarrativeManager.Instance;
    }

    void Update()
    {
        if (isDrinking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Drink();
            }

            // Comprobaci�n Final
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

        // Opcional: Ajusta la posici�n
        Vector3 newPosition = bottleContent.transform.position;
        newPosition.y -= drinkingSpeed / 2;
        bottleContent.transform.position = newPosition;

        timer += Time.deltaTime;
    }

    void FinishDrinking()
    {
        isDrinking = false;
        Debug.Log(timer + " segs");
        _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);
    }
}
