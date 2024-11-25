using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));

    [SerializeField] private PlayerMover _playerMover;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerMover.CharacterMoved += ChangeMotionStateAnimation;
    }

    private void OnDisable()
    {
        _playerMover.CharacterMoved -= ChangeMotionStateAnimation;
    }

    private void ChangeMotionStateAnimation(bool isWalking)
    {
        _animator.SetBool(IsWalking, isWalking);
    }
}