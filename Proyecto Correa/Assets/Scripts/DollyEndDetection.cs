using System;
using Unity.Cinemachine;
using UnityEngine;

public class DollyEndDetection : MonoBehaviour
{
    public CinemachineSplineDolly myCinemachineSplineDolly;
    private bool actAdvanced = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.IntroAct(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (myCinemachineSplineDolly.CameraPosition >= 2.0 && !actAdvanced)
        {
            actAdvanced = true;   
            changeScene();
        }
    }

    private void changeScene()
    {
        //NarrativeManager.Instance.AdvanceAct();     // 1.0 --> 1.1
        GameManager.Instance.ChangeScene("MinijuegoRegalo");
    }
}
