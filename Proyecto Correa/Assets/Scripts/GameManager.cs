using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton del GameManager
    public static GameManager Instance { get; private set; }
    [SerializeField] private UIManager _ui;
    public UIManager UI { get { return _ui; } }
    
    [SerializeField] private ProgressBarController _progressBarController;
    [SerializeField] private SceneTransitionManager _sceneTransitionManager;
    [SerializeField] private NarrativeManager _narrativeManager;

    [SerializeField] private GameObject _player;
    public GameObject GetPlayer() { return _player; }

    private BoxCollider _entertainment;

    [SerializeField] private GlobalEventRegistry _eventRegistry;
    
    private float _time;

    public void SetMinigames(BoxCollider go)
    {
        _entertainment = go;
    }
    
    public void CanPlayMiniGame(bool can)
    {
        Debug.Log("CAN: " + can);
        //_entertainment.enabled = can;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            if (_eventRegistry != null)
            {
                GlobalEvent globalEvent = _eventRegistry.GetEventByName("ChangeSceneEvent");
                if (globalEvent is StringEvent stringEvent)
                {
                    stringEvent.RegisterListener(ChangeScene);
                }
                globalEvent = _eventRegistry.GetEventByName("MinigameEnded");
                if (globalEvent is StringEvent events)
                {
                    events.RegisterListener(ChangeScene);
                }
                globalEvent = _eventRegistry.GetEventByName("ActivateMinigameEvent");
                if (globalEvent is BoolEvent boolEvent)
                {
                    boolEvent.RegisterListener(CanPlayMiniGame);
                }
            }
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


        // DEBUGGGG
        DebugToAct1();
    }

    public void NextLine(string text)
    {
        UI.ChangeDialogue(text);
    }

    public void DialogueEnded()
    {
        if (_ui != null)
        {
            _ui.OnDialogueEnd();
        }
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName + " [Cambio Escena]");
        DialogueEnded();
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

    // ESTO SE QUITARA
    public void DebugToAct1()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeScene("Acto1");
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
