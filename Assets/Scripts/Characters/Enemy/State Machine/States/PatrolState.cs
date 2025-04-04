public class PatrolState : State
{
    private Enemy _enemy;
    private EnemyStateMachine _stateMachine;
    private Player _player;
    private EnemyMover _enemyMover;
    private Patroller _patroller;
    private PlayerScaner _playerScaner;
    private Rotator _rotator;
    private CharacterAnimator _animator;

    private float _minDistanceToAttack = 1f;

    public PatrolState(Enemy enemy, EnemyStateMachine stateMachine, Player player, EnemyMover enemyMover, 
        Patroller patroller, PlayerScaner playerScaner, Rotator rotator, CharacterAnimator animator)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _player = player;
        _enemyMover = enemyMover;
        _patroller = patroller;
        _playerScaner = playerScaner;
        _rotator = rotator;
        _animator = animator;
    }

    public override void Enter()
    {
        _animator.SetWalkingAnimation();
        _rotator.UpdateFacing(_patroller.CurrentPointPosition);
        _enemyMover.SetSpeed(_patroller.PatrolMovingSpeed);
        _enemyMover.StartMoving();
    }

    public override void Exit()
    {
        _enemyMover.StopMoving();
    }

    public override void Update() 
    {
        if (_patroller.IsAtTargetPoint())
        {
            _patroller.UpdateToNextPoint();
            _rotator.UpdateFacing(_patroller.CurrentPointPosition);
        }
    }

    public override void FixedUpdate()
    {
        if (_playerScaner.IsPlayerInView() || Utilities.IsEnoughDistance(_enemy.transform.position, _player.transform.position, _minDistanceToAttack))
        {
            _stateMachine.ChangeState(_enemy.ChaseState);
        }
    }
}