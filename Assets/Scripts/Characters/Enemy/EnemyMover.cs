using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _routePoints;
    [SerializeField] private Rotator _rotator;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistanceToTargetPoint = 0.5f;

    private int _currentPointNumber = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _routePoints[_currentPointNumber].position, _speed * Time.deltaTime);

        if(IsEnoughDistance(transform.position, _routePoints[_currentPointNumber].position, _minDistanceToTargetPoint))
        {
            UpdateCurrentPoint();
            _rotator.Flip();
        }
    }

    private void UpdateCurrentPoint()
    {
        _currentPointNumber = (_currentPointNumber + 1) % _routePoints.Length;
    }

    private bool IsEnoughDistance(Vector3 thisPoint, Vector3 targetPoint, float distance)
    {
        return (targetPoint - thisPoint).sqrMagnitude <= distance * distance;
    }
}