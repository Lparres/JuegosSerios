using System;
using UnityEngine;

public class LastConvo : MonoBehaviour
{
    [SerializeField] private Guion _madre;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null)
        {
            _madre.NextLine();
        }
    }
}
