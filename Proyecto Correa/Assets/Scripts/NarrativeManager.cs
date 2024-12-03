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

    public void AdvanceAct(string a)
    {
        Debug.Log("AdvanceAct");
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
            Debug.Log(eventName);
            GlobalEvent globalEvent = _eventRegistry.GetEventByName(eventName);
            if (globalEvent is StringEvent stringEvent)
            {
                stringEvent.Raise(info);
            }
            else if (globalEvent is BoolEvent boolEvent)
            {
                boolEvent.Raise(true);
            }
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if (_eventRegistry != null)
            {
                GlobalEvent globalEvent = _eventRegistry.GetEventByName("MinigameEnded");
                if (globalEvent is StringEvent events)
                {
                    events.RegisterListener(AdvanceAct);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
