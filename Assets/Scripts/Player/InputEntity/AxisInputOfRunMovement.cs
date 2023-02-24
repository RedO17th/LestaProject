using UnityEngine;

public class AxisInputOfRunMovement : BaseInputOfMovement
{
    private Vector3 _inputVector = Vector3.zero;
    private Vector3 _direction2D = Vector3.zero;

    private bool _isRun = false;

    protected override void OnEnable()
    {
        base.OnEnable();

        _playerInputComponent.Player.Run.started += RunStarted;
        _playerInputComponent.Player.Run.canceled += RunCanceled;
    }

    private void RunStarted(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _isRun = context.started;
    }
    private void RunCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _isRun = context.started;
    }


    protected override void OnDisable()
    {
        _playerInputComponent.Player.Run.started -= RunStarted;
        _playerInputComponent.Player.Run.canceled -= RunCanceled;

        base.OnDisable();
    }

    public override bool IsInput() => _isRun && WalkInput();

    private bool WalkInput() => ReadInput() != Vector3.zero;
    private Vector3 ReadInput()
    {
        _direction2D = _playerInputComponent.Player.Move.ReadValue<Vector2>();

        _inputVector = new Vector3(_direction2D.x, 0f, _direction2D.y);

        return _inputVector;
    }

    public override Vector3 Read() => _inputVector;
}
