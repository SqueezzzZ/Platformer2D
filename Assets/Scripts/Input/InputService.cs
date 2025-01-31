using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode JumpKeyCode = KeyCode.Space;

    private bool _canJump;

    public bool CanJump => GetBoolAsTrigger(ref _canJump);
    public float HorizontalAxis { get; private set; }

    private void Update()
    {
        HorizontalAxis = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(JumpKeyCode))
            _canJump = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}