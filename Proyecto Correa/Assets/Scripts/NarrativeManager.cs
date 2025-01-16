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

    private float[] _meterSpeed;
    public float Speed
    {
        get
        {
            return _meterSpeed[_currentAct - 1];
        }
    }

    [SerializeField] private GlobalEventRegistry _eventRegistry;

    public void AdvanceAct(string a)
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
            else if (globalEvent is NormalEvent normalEvent)
            {
                normalEvent.Raise();
            }
        }
    }

    private void SetMeterReduceSpeed()
    {
        _meterSpeed = new float[5];
        
        _meterSpeed[0] = 0.1f;
        _meterSpeed[1] = 0.2f;
        _meterSpeed[2] = 0.5f;
        _meterSpeed[3] = 1f;
        _meterSpeed[4] = 2f;
    }

    private void Start()
    {
        SetMeterReduceSpeed();
    }

    private void Awake()
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
