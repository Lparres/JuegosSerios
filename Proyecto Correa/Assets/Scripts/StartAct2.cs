using UnityEngine;

public class StartAct2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameManager.Instance.GetNarrativeManager().SubIndex <= 0) GameManager.Instance.IntroAct(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
