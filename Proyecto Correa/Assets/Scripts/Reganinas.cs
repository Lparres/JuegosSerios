using System;
using UnityEngine;

public class Reganinas : MonoBehaviour
{
    bool castigoPadre = false;
    bool castigoMadre = false;
    NarrativeManager _narrative;
    
    [SerializeField] private GlobalEventRegistry _eventRegistry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _narrative = GameManager.Instance.GetNarrativeManager();
    }

    private void Awake()
    {
        if (_eventRegistry != null)
        {
            GlobalEvent globalEvent = _eventRegistry.GetEventByName("Castigao");
            if (globalEvent is StringEvent stringEvent)
            {
                stringEvent.RegisterListener(Castiga);
            }
        }
    }

    void Castiga(string npc)
    {
        if (npc == "Mama") castigoMadre = true;
        else if (npc == "Papa") castigoPadre = true;

        if(castigoMadre && castigoPadre)
        {
            // MINIGAMEENEDED NOP
            _narrative.EventByName("MinigameEnded", "Acto3-2");
        }
    }
}
