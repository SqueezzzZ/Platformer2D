using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private PlayerMover _playerMover;

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        float distance = Input.GetAxis(Horizontal);

        _playerMover.Move(distance);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.JumpUp();
        }
    }
}