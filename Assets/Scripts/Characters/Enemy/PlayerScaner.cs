using UnityEngine;

public class PlayerScaner : MonoBehaviour
{
    [SerializeField] private float _detectionRange;
    [SerializeField] private LayerMask _playerLayerMask;

    public bool TryGetPlayerInView(float distance, out Player foundPlayer)
    {
        RaycastHit2D raycastHit;

        raycastHit = Physics2D.Raycast(transform.position, transform.right, distance, _playerLayerMask);

        Debug.DrawRay(transform.position, transform.right * distance, Color.red, Time.fixedDeltaTime);

        if (raycastHit.transform == null || raycastHit.collider.TryGetComponent(out Player player) == false)
        {
            foundPlayer = null;
            return false;
        }

        foundPlayer = player;
        return true;
    }

    public bool TryGetPlayerInRadius(float radius, out Player foundPlayer)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            if(collider.TryGetComponent(out Player player))
            {
                foundPlayer = player;
                return true;
            }
        }

        foundPlayer = null;
        return false;
    }
}