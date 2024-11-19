using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton del GameManager
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager _ui;

    [SerializeField] private int currentAct = 1;

    [SerializeField] private ProgressBarController progressBarController;
    [SerializeField] private GameObject player;
    public GameObject getPlayer() { return player; }

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
        currentAct = newAct;
        Debug.Log("Acto " + currentAct);
    }

    public void ChangeScene(string sceneName)
    {
        // Carga la escena especificada por su nombre
        SceneManager.LoadScene(sceneName);
    }

    #region MEDIDORES
    public void UpdateHunger(float amount)
    {
        progressBarController.UpdateHunger(amount);
    }

    public void UpdateEntertainment(float amount)
    {
        progressBarController.UpdateEntertainment(amount);
    }

    public void UpdateWalk(float amount)
    {
        progressBarController.UpdateWalk(amount);
    }
    #endregion
}
