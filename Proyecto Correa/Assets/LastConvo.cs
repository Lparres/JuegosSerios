using System;
using UnityEngine;

public class LastConvo : MonoBehaviour
{
    [SerializeField] private Interactor2000 _interactor;
    [SerializeField] private Guion _madre;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null)
        {
            _interactor.SetNPC(_madre.gameObject);
            GameManager.Instance.OnDialogue = true;
            GameManager.Instance.GetPlayer().GetComponent<FirstPersonController>().enabled = false;
            _madre.NextLine();
        }
    }
}
