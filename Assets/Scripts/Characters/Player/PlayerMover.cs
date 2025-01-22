using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private CharacterAnimator _characterAnimator;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;
    private bool _isCharacterMoving;
    private float _movingDistanceDivider = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        JumpUp();
    }

    public void Move()
    {
        float inputDistance = _inputService.GetHorizontalAxis();

        if (inputDistance == 0)
        {
            if (_isCharacterMoving)
            {
                _isCharacterMoving = false;
                _characterAnimator.SetIdleAnimation();
            }

            return;
        }

        if(_isCharacterMoving == false)
        {
            _isCharacterMoving = true;
            _characterAnimator.SetWalkingAnimation();
        }

        if(_groundDetector.IsGrounded() == false)
        {
            inputDistance /= _movingDistanceDivider;
        }

        CheckFacing(inputDistance);
        transform.Translate(inputDistance * transform.right * (_speed * Time.deltaTime) );
    }

    public void JumpUp()
    {
        if (_inputService.IsJumpKeyPressed() == false)
            return;

        if (_groundDetector.IsGrounded() == false)
            return;

        Vector2 jumpForce = Vector2.up * _jumpPower;

        _rigidbody.AddForce(jumpForce);
    }

    private void CheckFacing(float distance)
    {
        if (distance < 0 && _rotator.IsRightFacing || distance > 0 && _rotator.IsRightFacing == false)
            _rotator.Flip();
    }
}