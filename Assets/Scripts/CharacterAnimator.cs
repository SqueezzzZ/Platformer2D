using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private readonly int _isWalking = Animator.StringToHash(nameof(_isWalking));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIdleAnimation()
    {
        _animator.SetBool(_isWalking, false);
    }

    public void SetWalkingAnimation()
    {
        _animator.SetBool(_isWalking, true);
    }
}