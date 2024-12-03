using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton del GameManager
    public static GameManager Instance { get; private set; }
    public UIManager UI { get; private set; } 
    
    [SerializeField] private ProgressBarController _progressBarController;
    [SerializeField] private SceneTransitionManager _sceneTransitionManager;
    [SerializeField] private NarrativeManager _narrativeManager;

    [SerializeField] private GameObject _player;
    public GameObject GetPlayer() { return _player; }

    [SerializeField] private EntertainmentGame _entertainment;
    [SerializeField] private WalkingGame _walk;
    [SerializeField] private FoodGame _food;

    private float _time;
    
    public void CanPlayMiniGame(bool can)
    {
        _entertainment.SetState(can);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            UI = transform.GetChild(0).GetChild(0).gameObject.GetComponent<UIManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_time == NarrativeManager.Instance.MeterThreshold)
        {
            _time = 0;
            UpdateHunger(-1);
            UpdateWalk(-1);
            UpdateEntertainment(-1);
        }
        else _time += Time.deltaTime;
    }

    public void NextLine(string text)
    {
        UI.ChangeDialogue(text);
    }

    public void DialogueEnded()
    {
        UI.OnDialogueEnd();
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName + " [Cambio Escena]");
        _sceneTransitionManager.ChangeScene(sceneName);
    }

    public void IntroAct(int act)
    {
        
        switch (act)
        {
            case 0:
                break;
            case 1:
                UI.intro1.SetActive(true);
                UI.intro1.GetComponent<IntroSequence>().playIntro();
                break;
        }
    }

    #region MEDIDORES
    public void UpdateHunger(float amount)
    {
        _progressBarController.UpdateHunger(amount);
    }

    public void UpdateEntertainment(float amount)
    {
        _progressBarController.UpdateEntertainment(amount);
    }

    public void UpdateWalk(float amount)
    {
        _progressBarController.UpdateWalk(amount);
    }
    #endregion
}
