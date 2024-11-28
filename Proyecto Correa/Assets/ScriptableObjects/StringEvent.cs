using UnityEngine;
using System;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ChangeSceneEvent", menuName = "Event/StringEvent")]
public class StringEvent : GlobalEvent
{
    private Action<string> _onEventRaised;

    public override void Raise()
    {
        Raise("default");
    }
    
    public void Raise(string message)
    {
        _onEventRaised?.Invoke(message);
    }
    
    public void RegisterListener(System.Action<string> listener)
    {
        _onEventRaised += listener;
    }

    public void UnregisterListener(System.Action<string> listener)
    {
        _onEventRaised -= listener;
    }
}
