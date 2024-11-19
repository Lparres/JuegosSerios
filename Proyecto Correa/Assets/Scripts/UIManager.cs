using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject _dialogue;
    private TMP_Text _textMeshPro;

    public void ChangeDialogue(string text)
    {
        _dialogue.SetActive(true);
        _textMeshPro.text = text;
    }

    public void OnDialogueEnd()
    {
        _dialogue.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dialogue = transform.GetChild(3).gameObject;
        _textMeshPro = _dialogue.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
