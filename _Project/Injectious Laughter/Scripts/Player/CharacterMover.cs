using UnityEngine;
using System;
using Zenject;

public class CharacterMover : MonoBehaviour
{
    public event Action<Vector2> MovementDirectionComputed;

    private CharacterConfig _config;
    private float _speed;

    private Vector2 _moveInput;
    private CharacterInput _input;
    private Rigidbody2D _rigidbody;

    [Inject]
    private void Construct(CharacterInput input, CharacterConfig config)
    {
        _input = input;
        _config = config;
        _speed = _config.Speed;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Enable();

    private void Update()
    {
        _moveInput = ReadMovementInput();
        MovementDirectionComputed?.Invoke(_moveInput);

        Move();
    }

    private void Move()
        => _rigidbody.velocity = new Vector2(_moveInput.x * _speed, _rigidbody.velocity.y);
        
    private Vector2 ReadMovementInput() => _input.Movement.Move.ReadValue<Vector2>();
}
