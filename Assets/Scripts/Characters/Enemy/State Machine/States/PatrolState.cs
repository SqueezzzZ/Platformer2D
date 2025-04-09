public class PatrolState : IState
{
    private Enemy _enemy;
    private IStateMachine _stateMachine;
    private EnemyMover _enemyMover;
    private Patroller _patroller;
    private PlayerScaner _playerScaner;
    private Rotator _rotator;
    private CharacterAnimator _animator;

    private float _detectionRadius = 1f;
    private float _viewDetectionRange = 5f;

    public PatrolState(IStateMachine stateMachine, Enemy enemy, EnemyMover enemyMover, 
        Patroller patroller, PlayerScaner playerScaner, Rotator rotator, CharacterAnimator animator)
    {
        _stateMachine = stateMachine;
        _enemy = enemy;
        _enemyMover = enemyMover;
        _patroller = patroller;
        _playerScaner = playerScaner;
        _rotator = rotator;
        _animator = animator;
    }

    public void Enter()
    {
        _animator.SetWalkingAnimation();
        _rotator.UpdateFacing(_patroller.CurrentPointPosition);
        _enemyMover.SetDirectedSpeed(_patroller.PatrolMovingSpeed);
        _enemyMover.StartMoving();
    }

    public void Exit()
    {
        _enemyMover.StopMoving();
    }

    public void Update() 
    {
        if (_patroller.IsAtTargetPoint())
        {
            _patroller.UpdateToNextPoint();
            _rotator.UpdateFacing(_patroller.CurrentPointPosition);
        }
    }

    public void FixedUpdate()
    {
        if (_playerScaner.TryGetPlayerInView(_viewDetectionRange, out Player player) || _playerScaner.TryGetPlayerInRadius(_detectionRadius, out player))
        {
            _enemy.SetTargetPlayer(player);
            _stateMachine.ChangeState<ChaseState>();
        }
    }
}