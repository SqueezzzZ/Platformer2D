using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] BoxCollider2D _collider;

    private float _boxCastRotation = 0f;

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, _boxCastRotation, Vector2.down, _groundCheckDistance, _groundLayerMask);
    }
}