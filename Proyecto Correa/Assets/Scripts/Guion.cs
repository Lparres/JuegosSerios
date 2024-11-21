using System.Dynamic;
using Ink.Runtime;
using UnityEngine;

public class Guion : MonoBehaviour
{
    // Set this file to your compiled json asset
    [SerializeField] 
    private TextAsset[] _act1TextAssets;
    [SerializeField]
    private TextAsset[] _act2TextAssets;
    [SerializeField]
    private TextAsset[] _act3TextAssets;
    [SerializeField]
    private TextAsset[] _act4TextAssets;
    [SerializeField]
    private TextAsset[] _act5TextAssets;

    private TextAsset[][] _textAssets = new TextAsset[5][];

    // The ink story that we're wrapping
    private Story _inkStory;

    private bool _interacting;

    public void NextDialogue()
    {
        Debug.Log("Next Dialogue");
        Vector2 storyPoint = GameManager.Instance.StoryPoint;
        _inkStory = new Story(_textAssets[(int)storyPoint.x - 1][(int)storyPoint.y].text);
    }

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
            _inkStory.ResetState();
            GameManager.Instance.DialogueEnded();
        }
    }

    void Start()
    {
        _textAssets[0] = _act1TextAssets;
        _textAssets[1] = _act2TextAssets;
        _textAssets[2] = _act3TextAssets;
        _textAssets[3] = _act4TextAssets;
        _textAssets[4] = _act5TextAssets;

        NextDialogue();
    }
}
