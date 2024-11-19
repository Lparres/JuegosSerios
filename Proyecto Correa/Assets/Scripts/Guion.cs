using Ink.Runtime;
using UnityEngine;

public class Guion : MonoBehaviour
{
    // Set this file to your compiled json asset
    [SerializeField] 
    private TextAsset _inkAsset;

    // The ink story that we're wrapping
    private Story _inkStory;

    public void NextLine()
    {
        if (_inkStory.canContinue)
        {
            GameManager.Instance.NextLine(_inkStory.Continue());
        }
        else
        {
            GameManager.Instance.DialogueEnded();
        }
    }

    void Awake()
    {
        _inkStory = new Story(_inkAsset.text);
    }
}
