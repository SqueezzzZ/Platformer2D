using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Character : MonoBehaviour 
{
    private readonly Quaternion _rightFacing = new Quaternion(0f, 0f, 0f, 0f);
    private readonly Quaternion _leftFacing = new Quaternion(0f, 180f, 0f, 0f);

    private BoxCollider2D _collider;

    public Bounds ColliderBounds => _collider.bounds;
    public bool IsRightFacing => transform.rotation.y == 0;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void Flip()
    {
        if(IsRightFacing == true)
        {
            transform.rotation = _leftFacing;
        }
        else
        {
            transform.rotation = _rightFacing;
        }
    }
}