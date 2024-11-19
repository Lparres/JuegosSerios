using Ink.Runtime;
using UnityEngine;

public class Guion : MonoBehaviour
{
    // Set this file to your compiled json asset
    [SerializeField] 
    private TextAsset _inkAsset;

    // The ink story that we're wrapping
    private Story _inkStory;

    private bool _interacting;

    public void LittleTalks()
    {
        if(!_interacting)
        {
            StartDialogue();
        }
        else
        {
            NextLine();
        }
    }

    private void StartDialogue()
    {
        _interacting = true;
        _inkStory.ChoosePathString("load_segment");
        NextLine();
    }

    private void NextLine()
    {
        if (_inkStory.canContinue)
        {
            GameManager.Instance.NextLine(_inkStory.Continue());
        }
        else
        {
            _interacting = false;
            GameManager.Instance.DialogueEnded();
        }
    }

    void Awake()
    {
        _inkStory = new Story(_inkAsset.text);
    }
}
