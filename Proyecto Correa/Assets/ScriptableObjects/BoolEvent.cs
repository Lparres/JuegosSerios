using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ChangeSceneEvent", menuName = "Event/BoolEvent")]
public class BoolEvent : GlobalEvent
{
    private Action<bool> _onEventRaised;

    public override void Raise()
    {
        Raise(true);
    }
    
    public void Raise(bool set)
    {
        _onEventRaised?.Invoke(set);
    }
    
    public void RegisterListener(System.Action<bool> listener)
    {
        _onEventRaised += listener;
    }

    public void UnregisterListener(System.Action<bool> listener)
    {
        _onEventRaised -= listener;
    }
}