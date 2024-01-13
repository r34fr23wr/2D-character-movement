using UnityEngine;

[CreateAssetMenu(menuName = "Source/Character/Config", fileName = "CharacterConfig", order = 0)]
public class CharacterConfig : ScriptableObject
{
    [Header("Commom")]
    [SerializeField, Range(0f,10f)] private float _speed;
    [Space]

    [SerializeField, Range(0f,20f)] private float _jumpForce;
    [SerializeField, Range(0f,1f)] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;
    [Space]

    [SerializeField, Min(0f)] private float _fallMultiplier = 2f;
    [SerializeField, Min(0f)] private float _lowJumpMultiplier = 1.5f;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float CheckRadius => _checkRadius;

    public LayerMask GroundLayer => _groundLayer;

    public float FallMultiplier => _fallMultiplier;
    public float LowJumpMultiplier => _lowJumpMultiplier;
}