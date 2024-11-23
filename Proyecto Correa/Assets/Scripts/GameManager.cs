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

    [SerializeField] private EntertainmentGame _entertainment;
    [SerializeField] private WalkingGame _walk;
    [SerializeField] private FoodGame _food;

    public void CanPlayMiniGame(bool can)
    {
        _entertainment.SetState(can);
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void NextLine(string text)
    {
        _ui.ChangeDialogue(text);
    }

    public void DialogueEnded()
    {
        _ui.OnDialogueEnd();
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName + " [Cambio Escena]");
        _sceneTransitionManager.ChangeScene(sceneName);
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
