using UnityEngine;
using Zenject;

public class CharacterJumper : MonoBehaviour
{
    [SerializeField] private Transform _feetPoint;

    private float _jumpForce;
    private float _checkRadius;
    private LayerMask _groundLayer;

    private bool _grounded;

    private CharacterInput _input;
    private CharacterConfig _config;
    private Rigidbody2D _rigidbody;

    [Inject]
    private void Construct(CharacterInput input, CharacterConfig config)
    {
        _input = input;
        _config = config;
        _rigidbody = GetComponent<Rigidbody2D>();

        _jumpForce = _config.JumpForce;
        _checkRadius = _config.CheckRadius;
        _groundLayer = _config.GroundLayer;
    }

    private void Update()
    {
        CheckGround();
        Jump();
    }

    private void CheckGround()
    {
        _grounded = Physics2D.OverlapCircle(_feetPoint.position, _checkRadius, _groundLayer);
    }

    private void Jump()
    {
        if(!_grounded)
            return;

        if(_input.Movement.Jump.WasPressedThisFrame())
        _rigidbody.velocity = Vector2.up * _jumpForce;     
    }
}
