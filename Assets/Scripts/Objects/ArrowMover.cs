using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    private float _arrowSpeed = 12;

    public void Move()
    {
        transform.Translate(Vector2.right * (_arrowSpeed * Time.deltaTime));
    }
}