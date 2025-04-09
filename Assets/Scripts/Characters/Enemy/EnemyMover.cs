using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Coroutine _movingCoroutine;

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void StartMoving()
    {
        IsMoving = true;
        _movingCoroutine = StartCoroutine(MoveFixed());
    }

    public void StopMoving()
    {
        StopCoroutine(_movingCoroutine);
        IsMoving = false;
    }

    public void SetDirectedSpeed(float speed)
    {
        _speed = speed;
    }

    private IEnumerator MoveFixed()
    {
        var wait = new WaitForFixedUpdate();

        while (IsMoving)
        {
            float xSpeed = _speed * transform.right.x;

            _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
            yield return wait;
        }
    }
}