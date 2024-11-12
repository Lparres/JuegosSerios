using Ink.Runtime;
using UnityEngine;

public class Guion : MonoBehaviour
{
    // Set this file to your compiled json asset
    [SerializeField] 
    private TextAsset _inkAsset;

    // The ink story that we're wrapping
    Story _inkStory;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(_inkStory.canContinue);
            if (_inkStory.canContinue)
            {
                Debug.Log("Siguiente linea: " + _inkStory.Continue());
            }
        }
    }

    void Awake()
    {
        _inkStory = new Story(_inkAsset.text);
    }
}