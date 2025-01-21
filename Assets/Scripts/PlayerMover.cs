using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    private readonly Quaternion _rightFacing = new Quaternion(0f,0f,0f,0f);
    private readonly Quaternion _leftFacing = new Quaternion(0f, 180f, 0f, 0f);

    [SerializeField] private StateInspector _stateInspector;
    [SerializeField] private CharacterAnimator _characterAnimator;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;
    private Player _player;
    private bool _isCharacterMoving;
    private float _movingDistanceDivider = 2f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    public void Move(float inputDistance)
    {
        if (inputDistance == 0)
        {
            if (_isCharacterMoving == true)
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

        if(_stateInspector.IsGrounded() == false)
        {
            inputDistance /= _movingDistanceDivider;
        }

        CheckFacing(inputDistance);
        transform.Translate(Mathf.Abs(inputDistance) * _speed * Vector3.right * Time.deltaTime);
    }

    public void JumpUp()
    {
        if (_stateInspector.IsGrounded() == false)
            return;

        Vector2 jumpForce = Vector2.up * _jumpPower;

        _rigidbody.AddForce(jumpForce);
    }

    private void CheckFacing(float distance)
    {
        if (distance < 0 && _player.IsRightFacing == true || distance > 0 && _player.IsRightFacing == false)
            _player.Flip();
    }
}