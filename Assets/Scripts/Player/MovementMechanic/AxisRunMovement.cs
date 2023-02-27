using UnityEngine;

public class AxisRunMovement : BaseMovementMechanic
{
    private BasePlayer _player = null;

    private float _runSpeed = 0f;
    private float _speedRotation = 0f;

    public override void Initialize(BasePlayerContoller controller)
    {
        base.Initialize(controller);

        _player = _movementController.Player;

        _input = controller.GetComponent<AxisInputOfRunMovement>();

        _runSpeed = _movementController.PlayerData.RunSpeed;
        _speedRotation = _movementController.PlayerData.SpeedRotation;
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
            var targetRotation = Quaternion.Slerp(_player.Rotation, rotation, Time.deltaTime * _speedRotation);

            _player.Rotate(targetRotation);
        }
    }
}
