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

    private GameObject _player;
    public GameObject GetPlayer() { return _player; }

    private BoxCollider _entertainment;
    private BoxCollider _food;
    private BoxCollider _walking;
    private BoxCollider _stairs;

    [SerializeField] private GlobalEventRegistry _eventRegistry;
    
    private float _time;

    public void SetPlayer(GameObject p)
    {
        _player = p;
    }

    public void SetStairs(BoxCollider go)
    {
        _stairs = go;
    }
    
    public void SetEntertainment(BoxCollider go)
    {
        _entertainment = go;
    }
    
    public void SetFoodGame(BoxCollider go)
    {
        _food = go;
    }
    
    public void SetWalkGame(BoxCollider go)
    {
        _walking = go;
    }
    
    private void CanPlayMiniGame(string game)
    {
        switch (game)
        {
           case "Entertainment":
               _entertainment.enabled = true;
               break;
           case "Food":
               _entertainment.enabled = true;
               break;
           case "Walk":
               _entertainment.enabled = true;
               break;
           case "Stairs":
               _stairs.enabled = true;
               break;
           default:
                   break;
        }
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
                if (globalEvent is StringEvent boolEvent)
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
        if(SceneManager.GetActiveScene().name == "Acto1"){
            UpdateHunger(-_narrativeManager.Speed * Time.deltaTime);
            UpdateWalk(-_narrativeManager.Speed * Time.deltaTime);
            UpdateEntertainment(-_narrativeManager.Speed * Time.deltaTime);
        }
        
        // DEBUGGGG
        DebugToAct1();
    }

    public void NextLine(string text)
    {
        UI.ChangeDialogue(text);
    }

    public void DialogueEnded()
    {
        if (_ui != null && _player != null)
        {
            _ui.OnDialogueEnd();
            _player.GetComponent<FirstPersonController>().enabled = true;
        }
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName + " [Cambio Escena]");
        DialogueEnded();
        //_progressBarController.ResetAllBars();
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
