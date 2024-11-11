using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton del GameManager
    public static GameManager Instance { get; private set; }

    [SerializeField] private int currentAct = 1;

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

    public void SetAct(int newAct)
    {
        currentAct = newAct;
        Debug.Log("Acto " + currentAct);
    }
}
