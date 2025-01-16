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
    
    [SerializeField] public ProgressBarController _progressBarController;
    private SceneTransitionManager _sceneTransitionManager;
    private NarrativeManager _narrativeManager;
    public NarrativeManager GetNarrativeManager() { return _narrativeManager; }

    private GameObject _player;
    public GameObject GetPlayer() { return _player; }

    private BoxCollider _entertainment;
    private BoxCollider _food;
    private BoxCollider _walking;
    private BoxCollider _stairs;

    [SerializeField] private GlobalEventRegistry _eventRegistry;
    
    private float _time;

    public Vector3 deathPosition = new Vector3(30, 0.5f, 0);
    
    public bool OnDialogue { get;  set; }

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
               _food.enabled = true;
               break;
           case "Walk":
               _walking.enabled = true;
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
        if(SceneManager.GetActiveScene().name != "Cinematica Inicio Navidad"){
            UpdateHunger(-_narrativeManager.Speed * Time.deltaTime);
            UpdateWalk(-_narrativeManager.Speed * Time.deltaTime);
            UpdateEntertainment(-_narrativeManager.Speed * Time.deltaTime);
        }

        DebugToActX();
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
            OnDialogue = false;
        }
    }

    public void ChangeScene(string sceneName)
    {
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
                GameManager.Instance.UpdateWalk(10);
                break;
            case 2:
                UI.intro2.SetActive(true);
                UI.intro2.GetComponent<IntroSequence>().playIntro();
                GameManager.Instance.UpdateWalk(10);
                break;
            case 3:
                UI.intro3.SetActive(true);
                UI.intro3.GetComponent<IntroSequence>().playIntro();
                GameManager.Instance.UpdateWalk(5);
                break;
            case 4:
                UI.intro4.SetActive(true);
                UI.intro4.GetComponent<IntroSequence>().playIntro();
                break;
            default: break;
        }
    }

    private void DebugToActX()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ChangeScene("Acto1");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ChangeScene("Acto2");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ChangeScene("Acto3");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            ChangeScene("Acto4");
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
