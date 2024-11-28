using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalEventRegistry", menuName = "Event/GlobalEventRegistry")]
public class GlobalEventRegistry : ScriptableObject
{
    [SerializeField] private List<GlobalEvent> _globalEvents;

    private Dictionary<string, GlobalEvent> _eventLookup;

    void OnEnable()
    {
        // Inicializamos el diccionario para acceso rápido
        _eventLookup = new Dictionary<string, GlobalEvent>();
        foreach (var globalEvent in _globalEvents)
        {
            _eventLookup.TryAdd(globalEvent.name, globalEvent);
        }
    }

    /// <summary>
    /// Devuelve un evento global por su nombre.
    /// </summary>
    public GlobalEvent GetEventByName(string eventName)
    {
        _eventLookup.TryGetValue(eventName, out var globalEvent);
        return globalEvent;
    }

    /// <summary>
    /// Devuelve una lista de eventos globales por tipo.
    /// </summary>
    public T GetEventByType<T>() where T : GlobalEvent
    {
        foreach (GlobalEvent globalEvent in _globalEvents)
        {
            if (globalEvent is T typedEvent)
            {
                return typedEvent;
            }
        }
        return null;
    }
}
