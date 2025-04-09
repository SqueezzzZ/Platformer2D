using UnityEngine;

public class Rotator : MonoBehaviour
{
    private readonly Quaternion _rightFacing = Quaternion.Euler(0, 0, 0);
    private readonly Quaternion _leftFacing = Quaternion.Euler(0f, 180.0f, 0f);

    public void UpdateFacing(float inputDirection)
    {
        if (inputDirection == 0)
            return;

        if (IsRightDirection(inputDirection) && IsRightFacing())
            return;

        if (IsRightDirection(inputDirection) == false && IsRightFacing() == false)
            return;

        Flip();
    }

    public void UpdateFacing(Vector3 targetPoint)
    {
        float offset = transform.position.x - targetPoint.x;

        if (offset == 0)
            return;

        if (offset > 0 && IsRightFacing() == false || offset < 0 && IsRightFacing())
            return;

        transform.rotation = offset > 0 ? _leftFacing : _rightFacing;
    }

    private void Flip()
    {
        transform.rotation = IsRightFacing() ? _leftFacing : _rightFacing;
    }

    private bool IsRightDirection(float inputDirection)
    {
        return inputDirection > 0;
    }

    private bool IsRightFacing()
    {
        return transform.rotation == _rightFacing;
    }
}