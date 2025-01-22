using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    private const KeyCode JumpKeyCode = KeyCode.Space;

    public float GetHorizontalAxis()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool IsJumpKeyPressed()
    {
        return Input.GetKeyDown(JumpKeyCode);
    }
}