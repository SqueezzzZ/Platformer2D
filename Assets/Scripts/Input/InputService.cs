using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode JumpKeyCode = KeyCode.Space;

    private bool _canJump;
    private bool _canAttack;

    public bool CanJump => GetBoolAsTrigger(ref _canJump);
    public bool CanAttack => GetBoolAsTrigger(ref _canAttack);
    public float HorizontalAxis { get; private set; }

    private void Update()
    {
        HorizontalAxis = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(JumpKeyCode))
            _canJump = true;

        if (Input.GetMouseButtonDown(0))
            _canAttack = true;
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}