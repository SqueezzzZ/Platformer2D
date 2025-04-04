using UnityEngine;

public class Waiter : MonoBehaviour
{
    [SerializeField] private float _coolDownTime= 3f;

    private float _endCoolDownTime;

    public float MinDistaceToAttack { get; private set; } = 2f;

    public void StartWaiting()
    {
        _endCoolDownTime = Time.time + _coolDownTime;
    }

    public bool CanStopWaiting()
    {
        return Time.time >= _endCoolDownTime;
    }
}