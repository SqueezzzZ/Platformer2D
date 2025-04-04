using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody;

    private float _movingDistanceDivider = 2f;
    private float _minVerticalSpeed = 0.05f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float inputDistance, bool isGrounded)
    {
        if (isGrounded == false && _rigidbody.velocity.y <= _minVerticalSpeed)
            return;

        inputDistance = isGrounded ? inputDistance : inputDistance / _movingDistanceDivider;

        _rigidbody.velocity = new Vector2(inputDistance * _speed, _rigidbody.velocity.y);
    }

    public void JumpUp()
    {
        Vector2 jumpForce = Vector2.up * _jumpPower;

        _rigidbody.AddForce(jumpForce);
    }

    public void Push(Vector2 direction, float power)
    {
        if (power <= 0 || direction == Vector2.zero)
            return;

        _rigidbody.AddForce(power * direction);
    }
}