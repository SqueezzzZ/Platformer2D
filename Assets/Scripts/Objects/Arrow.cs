using UnityEngine;
using System;

[RequireComponent(typeof(ArrowMover))]
public class Arrow : MonoBehaviour
{
    private ArrowMover _arrowMover;
    private Coroutine _lifetimeCorutine;
    private int _arrowDamage = 50;

    public event Action<Arrow> Collided;

    private void Awake()
    {
        _arrowMover = GetComponent<ArrowMover>();
    }

    private void Update()
    {
        _arrowMover.Move();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out Enemy enemy))
        {
            enemy.Damage(_arrowDamage);
            Collide();
        }
        else if(collider.TryGetComponent(out Ground ground))
        {
            Collide();
        }
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void SetLifetimeCoroutine(Coroutine coroutine)
    {
        _lifetimeCorutine = coroutine;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Collide()
    {
        StopCoroutine(_lifetimeCorutine);
        Collided?.Invoke(this);
    }
}