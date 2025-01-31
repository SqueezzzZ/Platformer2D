using UnityEngine;

[RequireComponent(typeof(InputService), typeof(PlayerMover))]
[RequireComponent(typeof(CharacterAnimator), typeof(GroundDetector))]
[RequireComponent(typeof(Rotator), typeof(Collector))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour 
{
    private InputService _inputService;
    private PlayerMover _playerMover;
    private CharacterAnimator _characterAnimator;
    private GroundDetector _groundDetector;
    private Rotator _rotator;
    private Collector _collector;
    private Wallet _wallet;

    private void Awake()
    {
        _inputService = GetComponent<InputService>();
        _playerMover = GetComponent<PlayerMover>();
        _characterAnimator = GetComponent<CharacterAnimator>();
        _groundDetector = GetComponent<GroundDetector>();
        _rotator = GetComponent<Rotator>();
        _collector = GetComponent<Collector>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _collector.PickedUp += OnCollect;
    }

    private void OnDisable()
    {
        _collector.PickedUp -= OnCollect;
    }

    private void FixedUpdate()
    {
        UpdateMoving();
        UpdateJumping();
    }

    private void UpdateMoving()
    {
        if (_inputService.HorizontalAxis != 0)
        {
            _playerMover.Move(_inputService.HorizontalAxis, _groundDetector.IsGrounded());
            _rotator.UpdateFacing(_inputService.HorizontalAxis);

            if (_characterAnimator.IsWalkingAnim == false)
            {
                _characterAnimator.SetWalkingAnimation();
            }
        }
        else if (_characterAnimator.IsWalkingAnim)
        {
            _characterAnimator.SetIdleAnimation();
        }
    }

    private void UpdateJumping()
    {
        if(_inputService.CanJump && _groundDetector.IsGrounded())
            _playerMover.JumpUp();
    }

    private void OnCollect(Pickupable pickupable)
    {
        if(pickupable.TryGetComponent(out Coin coin))
            _wallet.AddCoins(coin.Price);

        pickupable.Collect();
    }
}