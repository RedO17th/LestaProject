using UnityEngine;

public class AxisWalkMovement : BaseMovementMechanic
{
    private GamePlayer _player = null;

    public override void Initialize(BasePlayerContoller controller)
    {
        base.Initialize(controller);

        _player = _movementController.Player;

        _input = controller.GetComponent<AxisInputOfMovement>();
    }

    public override void Move()
    {
        _navMeshAgent.Move(_input.Read() * Time.deltaTime);
    }

    public override void Rotate()
    {
        var inputDirection = _input.Read();
        var directionRotation = new Vector3(inputDirection.x, 0f, inputDirection.z);
        if (directionRotation.magnitude != 0f)
        {
            var rotation = Quaternion.LookRotation(directionRotation);
            var targetRotation = Quaternion.Slerp(_player.Rotation, rotation, Time.deltaTime * 5f);

            _player.Rotate(targetRotation);
        }
    }
}