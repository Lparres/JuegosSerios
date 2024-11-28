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

    [SerializeField] private GlobalEventRegistry _eventRegistry;

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
        if (_eventRegistry != null)
        {
            GlobalEvent globalEvent = _eventRegistry.GetEventByName(eventName);
            if (globalEvent is StringEvent stringEvent)
            {
                stringEvent.Raise(info);
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
