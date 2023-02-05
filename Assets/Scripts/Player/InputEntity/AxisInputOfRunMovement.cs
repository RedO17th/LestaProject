using UnityEngine;

public class AxisInputOfRunMovement : BaseInputOfMovement
{
    private Vector3 _inputVector = Vector3.zero;

    public override bool IsInput() => RunInput() && WalkInput();

    private bool RunInput() => Input.GetKey(KeyCode.LeftShift);

    private bool WalkInput() => ReadInput() != Vector3.zero;

    private Vector3 ReadInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _inputVector = new Vector3(horizontal, 0f, vertical);

        return _inputVector;
    }

    public override Vector3 Read() => _inputVector;
}
