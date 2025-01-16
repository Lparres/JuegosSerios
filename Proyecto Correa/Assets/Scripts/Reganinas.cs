using UnityEngine;

public class Reganinas : MonoBehaviour
{
    bool castigoPadre = false;
    bool castigoMadre = false;
    NarrativeManager _narrative;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _narrative = GameManager.Instance.GetNarrativeManager();
    }

    void mamaMeCastiga()
    {
        castigoMadre = true;
        if(castigoMadre && castigoPadre)
        {
            // MINIGAMEENEDED NOP
            _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);
        }
    }

    void papaMeCastiga()
    {
        castigoPadre = true;
        if(castigoMadre && castigoPadre)
        {
            // MINIGAMEENEDED NOP
            _narrative.EventByName("MinigameEnded", "Acto" + _narrative.Act);
        }
    }
}
