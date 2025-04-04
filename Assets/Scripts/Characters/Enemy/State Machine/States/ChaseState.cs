public class ChaseState : State
{
    private Enemy _enemy;
    private Player _player;
    private EnemyStateMachine _enemyStateMachine;
    private EnemyMover _enemyMover;
    private Rotator _rotator;
    private CharacterAnimator _animator;

    private float _minDistanceToPlayer = 5f;

    public ChaseState(Enemy enemy, Player player, EnemyStateMachine enemyStateMachine, EnemyMover enemyMover, Rotator rotator, CharacterAnimator animator)
    {
        _enemy = enemy;
        _player = player;
        _enemyStateMachine = enemyStateMachine;
        _enemyMover = enemyMover;
        _rotator = rotator;
        _animator = animator;
    }

    public override  void Enter()
    {
        _animator.SetWalkingAnimation();
        _enemyMover.SetSpeed(_enemy.ChasingMovingSpeed);
        _enemyMover.StartMoving();
    }

    public override void Exit()
    {
        _enemyMover.StopMoving();
    }

    public override void Update() {  }

    public override void FixedUpdate()
    {
        _rotator.UpdateFacing(_player.transform.position);

        if (Utilities.IsEnoughDistance(_enemy.transform.position, _player.transform.position, _minDistanceToPlayer) == false)
        {
            _enemyStateMachine.ChangeState(_enemy.WaitState);
        }
    }
}