using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private RoutePointTrigger _routePointTrigger;
    [SerializeField] private Transform[] _routePoints;
    [SerializeField] private bool _isMoving;
    [SerializeField] private float _speed;

    private int _currentPointNumber = 0;

    private void OnEnable()
    {
        _routePointTrigger.TriggerEntered += UpdateCurrentPoint;
    }

    private void OnDisable()
    {
        _routePointTrigger.TriggerEntered -= UpdateCurrentPoint;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(_isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _routePoints[_currentPointNumber].position, _speed * Time.deltaTime);
        }
    }

    private void UpdateCurrentPoint()
    {
        _currentPointNumber = (_currentPointNumber + 1) % _routePoints.Length;
    }
}