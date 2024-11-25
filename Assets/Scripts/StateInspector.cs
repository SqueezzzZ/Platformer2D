using UnityEngine;

public class StateInspector : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundLayerMask;

    private float _boxCastRotation = 0f;

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_character.ColliderBounds.center, _character.ColliderBounds.size, _boxCastRotation, Vector2.down, _groundCheckDistance, _groundLayerMask);
    }
}