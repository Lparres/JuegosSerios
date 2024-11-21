using TMPro;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject _dialogue;
    private TMP_Text _message;

    public void ChangeDialogue(string text)
    {
        _dialogue.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text));
    }

    public void OnDialogueEnd()
    {
        _dialogue.SetActive(false);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        _message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _message.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dialogue = transform.GetChild(3).gameObject;
        _message = _dialogue.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
