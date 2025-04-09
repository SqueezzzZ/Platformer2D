public class ChaseState : IState
{
    private IStateMachine _stateMachine;
    private Enemy _enemy;
    private EnemyMover _enemyMover;
    private Rotator _rotator;
    private CharacterAnimator _animator;

    private float _minDistanceToPlayer = 5f;
    private float _chasingMovingSpeed = 1.4f;

    public ChaseState(IStateMachine stateMachine, Enemy enemy, EnemyMover enemyMover, Rotator rotator, CharacterAnimator animator)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _enemyMover = enemyMover;
        _rotator = rotator;
        _animator = animator;
    }

    public void Enter()
    {
        _animator.SetWalkingAnimation();
        _enemyMover.SetDirectedSpeed(_chasingMovingSpeed);
        _enemyMover.StartMoving();
    }

    public void Exit()
    {
        _enemyMover.StopMoving();
    }

    public void Update() {  }

    public void FixedUpdate()
    {
        _rotator.UpdateFacing(_enemy.TargetPlayer.transform.position);

        if (Utilities.IsEnoughDistance(_enemy.transform.position, _enemy.TargetPlayer.transform.position, _minDistanceToPlayer) == false)
        {
            _enemy.SetTargetPlayer(null);
            _stateMachine.ChangeState<WaitState>();
        }
    }
}