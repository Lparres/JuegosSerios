using System;
using System.Collections.Generic;
using Ink.Parsed;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager Instance { get; private set; }

    [SerializeField] private int _currentAct = 1;
    public int Act { get { return _currentAct; } }
    [SerializeField] private int _subIndexAct = 0;
    public int SubIndex { get { return _subIndexAct; } }
    
    public Vector2 StoryPoint { get { return new Vector2(_currentAct, _subIndexAct); } }

    public float MeterThreshold { get; private set; } = 10;

    [SerializeField] private List<GlobalEvent> _storyEvents;

    public void AdvanceAct()
    {
        _subIndexAct++;
    }
    
    public void NextAct()
    {
        _currentAct++;
        _subIndexAct = 0;
    }

    public void EventByName(string eventName, string info)
    {
        foreach (GlobalEvent globalEvent in _storyEvents)
        {
            if (globalEvent is StringEvent stringEvent && stringEvent.name == eventName)
            {
                stringEvent.Raise(info);
                return;
            }
        }
    }

    private void Start()
    {
        foreach (GlobalEvent e in _storyEvents)
        {
            if (e is StringEvent s)
            {
                switch (s.name)
                {
                    case "ChangeSceneEvent":
                        s.RegisterListener(info => GameManager.Instance.ChangeScene(info));
                        break;
                }
            }
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
