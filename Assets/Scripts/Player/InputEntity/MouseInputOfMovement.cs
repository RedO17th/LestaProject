using UnityEngine;

public class MouseInputOfMovement : BaseInputOfMovement
{
    public override bool IsInput() => Input.GetMouseButton(0);

    public override Vector3 Read()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        { 
            return hit.point;
        }

        return Vector3.zero;
    }
}
