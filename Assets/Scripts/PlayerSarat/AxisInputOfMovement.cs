using UnityEngine;

public class AxisInputOfMovement : BaseInputOfMovement
{
    private Vector3 _inputVector = Vector3.zero;

    public override bool IsInput() => ReadInput() != Vector3.zero;

    private Vector3 ReadInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _inputVector =  new Vector3(horizontal, 0f, vertical);

        return _inputVector;
    }

    public override Vector3 Read() => _inputVector;
}