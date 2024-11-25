using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private StateInspector _stateInspector;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;
    private bool _isCharacterMoving;
    private bool _isDefaultDirection = true;
    private float _movingDistanceDivider = 2f;

    public event Action DirectionChanged;
    public event Action<bool> CharacterMoved;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        JumpUp();
    }

    private void Move()
    {
        float distance = Input.GetAxis(Horizontal) * _speed * Time.deltaTime;

        if (distance == 0)
        {
            if (_isCharacterMoving == true)
            {
                _isCharacterMoving = false;
                CharacterMoved?.Invoke(_isCharacterMoving);
            }

            return;
        }

        if(_isCharacterMoving == false)
        {
            _isCharacterMoving = true;
            CharacterMoved?.Invoke(_isCharacterMoving);
        }

        if(_stateInspector.IsGrounded() == false)
        {
            distance /= _movingDistanceDivider;
        }

        CheckDirection(distance);
        transform.Translate(distance * Vector3.right);
    }

    private void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _stateInspector.IsGrounded() == true)
        {
            Vector2 jumpForce = Vector2.up * _jumpPower;

            _rigidbody.AddForce(jumpForce);
        }
    }

    private void CheckDirection(float distance)
    {
        if (distance < 0 && _isDefaultDirection == true)
        {
            _isDefaultDirection = false;
            DirectionChanged?.Invoke();
        }
        else if(distance > 0 && _isDefaultDirection == false)
        {
            _isDefaultDirection = true;
            DirectionChanged?.Invoke();
        }
    }
}