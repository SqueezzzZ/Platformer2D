using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _routePoints;

    private int _currentPointNumber = 0;
    private Vector3 _targetPoint;
    private float _minDistanceToTargetPoint = 0.5f;

    public float PatrolMovingSpeed { get; private set; } = 0.8f;

    public Vector3 CurrentPointPosition => _routePoints[_currentPointNumber].position;

    private void Start()
    {
        SetTargetPoint(CurrentPointPosition);
    }

    public void UpdateToNextPoint()
    {
        _currentPointNumber = ++_currentPointNumber % _routePoints.Length;
        SetTargetPoint(CurrentPointPosition);
    }

    public bool IsAtTargetPoint()
    {
        return Utilities.IsEnoughDistance(transform.position, _targetPoint, _minDistanceToTargetPoint);
    }

    private void SetTargetPoint(Vector3 point)
    {
        _targetPoint = point;
    }
}