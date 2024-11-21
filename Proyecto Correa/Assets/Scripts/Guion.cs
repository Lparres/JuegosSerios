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

    private Vector2 _storyPoint;

    public void NextDialogue()
    {
        Debug.Log("Next Dialogue");
        Debug.Log(GameManager.Instance);
        _storyPoint = new Vector2(GameManager.Instance.Act, GameManager.Instance.SubIndex);
        Debug.Log(_storyPoint);
        _inkStory = new Story(_textAssets[(int)_storyPoint.x - 1][(int)_storyPoint.y].text);
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
