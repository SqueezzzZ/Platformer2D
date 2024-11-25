using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class CharacterReflector : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private bool _isDefaultDirection;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _playerMover.DirectionChanged += FlipSprite;
    }

    private void OnDisable()
    {
        _playerMover.DirectionChanged -= FlipSprite;
    }

    private void FlipSprite()
    {
        if (_isDefaultDirection == true && _renderer.flipX == false)
        {
            _isDefaultDirection = false;
            _renderer.flipX = true;
        }
        else
        {
            _isDefaultDirection = true;
            _renderer.flipX = false;
        }
    }
}