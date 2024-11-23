using TMPro;
using System.Collections;
using NUnit.Framework.Internal.Commands;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject _dialogue;
    private TMP_Text _message;
    private string _sentence;
    
    public void ChangeDialogue(string text)
    {
        _dialogue.SetActive(true);
        _sentence = text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence());
    }

    public void OnDialogueEnd()
    {
        _dialogue.SetActive(false);
    }

    private IEnumerator TypeSentence()
    {
        _message.text = "";
        foreach (char letter in _sentence.ToCharArray())
        {
            _message.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Skip()
    {
        StopAllCoroutines();
        _message.text = _sentence;
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
