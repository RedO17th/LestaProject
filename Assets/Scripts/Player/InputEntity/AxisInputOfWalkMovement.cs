using UnityEngine;

public class AxisInputOfWalkMovement : BaseInputOfMovement
{
    private Vector3 _inputVector = Vector3.zero;
    private Vector3 _direction2D = Vector3.zero;

    public override bool IsInput() => ReadInput() != Vector3.zero;

    private Vector3 ReadInput()
    {
        _direction2D = _playerInputComponent.Player.Move.ReadValue<Vector2>();

        _inputVector =  new Vector3(_direction2D.x, 0f, _direction2D.y);

        return _inputVector;
    }

    public override Vector3 Read() => _inputVector;
}