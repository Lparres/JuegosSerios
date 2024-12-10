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
    private SceneTransitionManager _sceneTransitionManager;
    private NarrativeManager _narrativeManager;

    [SerializeField] private GameObject _player;
    public GameObject GetPlayer() { return _player; }

    [SerializeField] private BoxCollider _entertainment;

    [SerializeField] private GlobalEventRegistry _eventRegistry;
    
    private float _time;

    public void SetMinigames(BoxCollider go)
    {
        _entertainment = go;
    }
    
    private void CanPlayMiniGame(bool can)
    {
        Debug.Log("CAN MINIGAME: " + can);
        _entertainment.enabled = can;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _narrativeManager = GetComponent<NarrativeManager>();
            _sceneTransitionManager = GetComponent<SceneTransitionManager>();
            
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
        UpdateHunger(-_narrativeManager.Speed * Time.deltaTime);
        UpdateWalk(-_narrativeManager.Speed * Time.deltaTime);
        UpdateEntertainment(-_narrativeManager.Speed * Time.deltaTime);
        
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
            _player.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName + " [Cambio Escena]");
        DialogueEnded();
        _progressBarController.ResetAllBars();
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
    private void DebugToAct1()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeScene("Acto1");
        }
    }
    #region MEDIDORES
    private void UpdateHunger(float amount)
    {
        _progressBarController.UpdateHunger(amount);
    }

    private void UpdateEntertainment(float amount)
    {
        _progressBarController.UpdateEntertainment(amount);
    }

    private void UpdateWalk(float amount)
    {
        _progressBarController.UpdateWalk(amount);
    }
    #endregion
}
