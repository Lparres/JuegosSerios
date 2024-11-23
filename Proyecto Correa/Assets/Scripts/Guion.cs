using System.Collections.Generic;
using System.Dynamic;
using Ink.Runtime;
using UnityEngine;

public class Guion : MonoBehaviour
{
    // Set this file to your compiled json asset
    [SerializeField] private List<TextAsset> _act1TxtAssets;
    [SerializeField] private List<TextAsset> _act2TxtAssets;
    [SerializeField] private List<TextAsset> _act3TxtAssets;
    [SerializeField] private List<TextAsset> _act4TxtAssets;
    [SerializeField] private List<TextAsset> _act5TxtAssets;

    private List<List<TextAsset>> _textAssets;
    
    private List<List<Story>> _inkStories;
    
    private StoryEvent _event;

    public void NextLine()
    {
        Vector2 point = NarrativeManager.Instance.StoryPoint;
        Story activeStory = _inkStories[(int)point.x][(int)point.y];
        
        if (activeStory.canContinue)
        {
            GameManager.Instance.NextLine(activeStory.Continue());
        }
        else
        {
            activeStory.ResetState();
            GameManager.Instance.DialogueEnded();
        }
    }

    private void SetStories()
    {
        foreach (List<TextAsset> act in _textAssets)
        {
            List<Story> actStories = new List<Story>();
            foreach (TextAsset asset in act)
            {
                Story s = new Story(asset.text);
                s.BindExternalFunction("StoryEvent", () =>
                {
                    _event.OnStoryEvent();
                });
                
                actStories.Add(s);
            }
            
            _inkStories.Add(actStories);
        }
    }

    void Start()
    {
        _textAssets = new List<List<TextAsset>>();
        _inkStories = new List<List<Story>>();
        _event = GetComponent<StoryEvent>();
        
        _textAssets.Add(_act1TxtAssets);
        _textAssets.Add(_act2TxtAssets);
        _textAssets.Add(_act3TxtAssets);
        _textAssets.Add(_act4TxtAssets);
        _textAssets.Add(_act5TxtAssets);

        SetStories();
    }
}
