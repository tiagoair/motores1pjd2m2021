using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidade;

    [SerializeField] private PlayerInput playerInput;

    private GameInput _gameInput;

    private Vector2 _moveInput;

    private Rigidbody2D _rigidbody2D;
    
    private void OnEnable()
    {
        playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= OnActionTriggered;
    }


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _gameInput = new GameInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_moveInput * velocidade);
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name == _gameInput.Gameplay.Move.name)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }
    }
}
