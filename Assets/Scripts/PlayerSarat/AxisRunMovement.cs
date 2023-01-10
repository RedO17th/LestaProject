using UnityEngine;

public class AxisRunMovement : BaseMovementMechanic
{
    private GamePlayer _player = null;

    private float _runSpeed = 0f;

    public override void Initialize(BasePlayerContoller controller)
    {
        base.Initialize(controller);

        _player = _movementController.Player;

        _input = controller.GetComponent<AxisInputOfRunMovement>();

        _runSpeed = _movementController.RunSpeed;
    }

    public override void Move()
    {
        _currentSpeed = _runSpeed;

        _navMeshAgent.Move(_input.Read() * _currentSpeed * Time.deltaTime);
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
