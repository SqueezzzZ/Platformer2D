using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Character : MonoBehaviour 
{
    private BoxCollider2D _collider;

    public Bounds ColliderBounds => _collider.bounds;
    public Vector3 Position => transform.position;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
}