using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton del GameManager
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager _ui;

    [SerializeField] private int _currentAct = 1;

    [SerializeField] private ProgressBarController _progressBarController;
    [SerializeField] private GameObject _player;
    public GameObject GetPlayer() { return _player; }

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

    public void SetAct(int newAct)
    {
        _currentAct = newAct;
        Debug.Log("Acto " + _currentAct);
    }

    public void ChangeScene(string sceneName)
    {
        // Carga la escena especificada por su nombre
        SceneManager.LoadScene(sceneName);
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
