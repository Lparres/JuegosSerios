using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NormalEvent", menuName = "Event/NormalEvent")]
public class NormalEvent : GlobalEvent
{
    private Action _onEventRaised;

    public override void Raise()
    {
        _onEventRaised?.Invoke();
    }
    
    public void RegisterListener(System.Action listener)
    {
        _onEventRaised += listener;
    }

    public void UnregisterListener(System.Action listener)
    {
        _onEventRaised -= listener;
    }
}
