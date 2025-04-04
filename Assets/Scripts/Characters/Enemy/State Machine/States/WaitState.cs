public class WaitState : State
{
    private Enemy _enemy;
    private EnemyStateMachine _enemyStateMachine;
    private Player _player;
    private CharacterAnimator _animator;
    private Waiter _waiter;

    public WaitState(Enemy enemy, EnemyStateMachine enemyStateMachine, Player player, CharacterAnimator animator, Waiter waiter)
    {
        _enemy = enemy;
        _enemyStateMachine = enemyStateMachine;
        _player = player;
        _animator = animator;
        _waiter = waiter;
    }

    public override void Enter()
    {
        _animator.SetIdleAnimation();
        _waiter.StartWaiting();
    }

    public override void Exit() { }

    public override void Update() 
    { 
        if(Utilities.IsEnoughDistance(_enemy.transform.position, _player.transform.position, _waiter.MinDistaceToAttack))
        {
            _enemyStateMachine.ChangeState(_enemy.ChaseState);
            return;
        }

        if(_waiter.CanStopWaiting())
        {
            _enemyStateMachine.ChangeState(_enemy.PatrolState);
        }
    }

    public override void FixedUpdate() { }
}