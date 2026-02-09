using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IControllable
{
    private InputSystem _inputSystem;
    private Interact _interact;
    private Rigidbody2D _rb;
    
    public bool CanControl = true;
    
    [SerializeField] private float _speed;

    private void Awake()
    {
        _inputSystem = new InputSystem();
        _inputSystem.Enable();
        
        _interact = GetComponent<Interact>();
        
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (CanControl)
        {
            Move(ReadMovement());
        }
    }
    
    private void OnEnable()
    {
        _inputSystem.Gameplay.Interact.performed += Interact;
    }
    
    private void OnDisable()
    {
        _inputSystem.Gameplay.Interact.performed -= Interact;
    }

    private Vector2 ReadMovement()
    {
        return _inputSystem.Gameplay.Movement.ReadValue<Vector2>();
    }

    public void Move(Vector2 direction)
    {
        direction.Normalize();
        transform.Translate(direction * (_speed * Time.deltaTime));
    }

    public void Interact(InputAction.CallbackContext obj)
    {
        if (CanControl)
        {
            _interact.MakeInterraction();
        }
    }

    private void OnDestroy()
    {
        _inputSystem.Disable();
    }
}
