using UnityEngine;
using Zenject;

public class GravityHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _fallMultiplier = 2f, _lowJumpMultiplier = 1.5f;

    private CharacterConfig _config;

    [Inject]
    private void Construct(CharacterConfig config)
    {
        _config = config;
        _rigidbody = GetComponent<Rigidbody2D>();

        _fallMultiplier = _config.FallMultiplier;
        _lowJumpMultiplier = _config.LowJumpMultiplier;
    }

    private void Update()
    {
        if(_rigidbody.velocity.y < 0)
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        else if(_rigidbody.velocity.y > 0)
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
    }
}
