using UnityEngine;
using System;

[CreateAssetMenu(fileName = "StringEvent", menuName = "Event/StringEvent")]
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

    public void RegisterListener(Action<string> listener)
    {
        _onEventRaised += listener;
    }

    public void UnregisterListener(Action<string> listener)
    {
        _onEventRaised -= listener;
    }
}
