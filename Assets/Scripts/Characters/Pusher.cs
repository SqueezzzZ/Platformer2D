using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pusher : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Push(Vector2 direction, float power)
    {
        if (power <= 0 || direction == Vector2.zero)
            return;

        _rigidbody.AddForce(power * direction);
    }
}