using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _input;
    private InputAction _interactAction;
    private UIManager _ui;
    private Interactor2000 _i2000;

    void OnEnable()
    {
        _interactAction.performed += OnInteract;
    }

    void OnDisable()
    {
        _interactAction.performed -= OnInteract;
    }

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _interactAction = _input.actions["Interact"];
    }

    void Start()
    {
        _ui = GameManager.Instance.UI;
        if (Camera.main != null) _i2000 = Camera.main.GetComponent<Interactor2000>();
    }
    
    private void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("CLICK");
        _ui.Skip(); 
        _i2000.Interact();
    }
}
