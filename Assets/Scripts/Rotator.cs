using UnityEngine;

public class Rotator : MonoBehaviour
{
    private readonly Quaternion _rightFacing = new Quaternion(0f, 0f, 0f, 0f);
    private readonly Quaternion _leftFacing = new Quaternion(0f, 180f, 0f, 0f);

    public bool IsRightFacing => transform.rotation.y == 0;

    public void Flip()
    {
        if (IsRightFacing)
            transform.rotation = _leftFacing;
        else
            transform.rotation = _rightFacing;
    }
}