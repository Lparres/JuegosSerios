using TMPro;
using System.Collections;
using NUnit.Framework.Internal.Commands;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject _dialogue;
    private TMP_Text _message;
    private string _sentence;
    public bool Typing { get; private set; }

    public void ChangeDialogue(string text)
    {
        if (!Typing && text.Length != 0) 
        {
            _dialogue.SetActive(true);
            _sentence = text;
            StopAllCoroutines();
            StartCoroutine(TypeSentence());
        }
    }

    public void OnDialogueEnd()
    {
        _dialogue.SetActive(false);
    }

    private IEnumerator TypeSentence()
    {
        Typing = true;
        _message.text = "";
        foreach (char letter in _sentence.ToCharArray())
        {
            _message.text += letter;
            yield return new WaitForSeconds(0.1f);
        }

        Typing = false;
    }

    public void Skip()
    {
        if (Typing) {
            StopAllCoroutines();
            _message.text = _sentence;
            Typing = false;
        }
    }

    public void DissapearObject(GameObject myObj)
    {
        myObj.SetActive(false);
    }

    public void AppearObject(GameObject myObj)
    {
        myObj.SetActive(true);
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
