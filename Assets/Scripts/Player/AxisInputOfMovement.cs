using UnityEngine;

public class AxisInputOfMovement : BaseInputOfMovement
{
    public override Vector3 Read()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, -Physics.gravity.magnitude, vertical);
    }
}