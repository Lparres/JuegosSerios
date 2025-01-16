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
        if (NarrativeManager.Instance.Act == 1) drinkingSpeed = 0.1f;
        if (NarrativeManager.Instance.Act == 2) drinkingSpeed = 0.25f;
    }

    void Update()
    {
        if (isDrinking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Drink();
            }

            if (bottleContent.transform.localScale.y <= scaleThreshold)
            {
                FinishDrinking();
            }
        }
    }

    void Drink()
    {
        Vector3 newScale = bottleContent.transform.localScale;
        newScale.y -= drinkingSpeed;
        bottleContent.transform.localScale = newScale;

        Vector3 newPosition = bottleContent.transform.position;
        newPosition.y -= drinkingSpeed / 2;
        bottleContent.transform.position = newPosition;

        GameManager.Instance.UpdateHunger(1);
        timer += Time.deltaTime;
    }

    void FinishDrinking()
    {
        isDrinking = false;
        Debug.Log(timer + " segs");
        _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);
    }
}
