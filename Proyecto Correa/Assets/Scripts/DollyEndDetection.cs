using System;
using Unity.Cinemachine;
using UnityEngine;

public class DollyEndDetection : MonoBehaviour
{
    public CinemachineSplineDolly myCinemachineSplineDolly;
    public SceneTransitionManager mySceneTransitionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (myCinemachineSplineDolly.CameraPosition >= 2.0)
        {
            mySceneTransitionManager.ChangeScene("MinijuegoRegalo");
        }
    }
}
