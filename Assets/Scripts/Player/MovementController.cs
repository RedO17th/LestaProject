using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MovementController : BasePlayerContoller
{
    [SerializeField] private NavMeshAgent _navMeshAgent = null;

    //TODO: Transfer to Settings system
    [Range(5f, 25f)]
    [SerializeField] private float _speedMovement = 5f;
    [Range(5f, 50f)]
    [SerializeField] private float _speedRotation = 5f;
    //..

    public event Action OnPlayerMove;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private BaseMovementMechanic[] _movementMechanics = null;
    private BaseMovementMechanic _currentMovementMechanic = null;

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);

        _movementMechanics = new BaseMovementMechanic[]
        {
            new AxisMovement(this),
            new MouseMovement(this)
        };

        _currentMovementMechanic = _movementMechanics[0];
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var mechanic = DefineMovementMechanic();

        PerformMovementMechanic(mechanic);
    }

    private BaseMovementMechanic DefineMovementMechanic()
    {
        BaseMovementMechanic mechanic = null;

        foreach (var mech in _movementMechanics)
        {
            if (mech.IsInput)
                return mech;
        }

        return mechanic;
    }

    private void PerformMovementMechanic(BaseMovementMechanic mechanic)
    {
        if (mechanic != null)
        {
            
            if (mechanic.Type != _currentMovementMechanic.Type)
            {
                _currentMovementMechanic.Stop();
                _currentMovementMechanic = mechanic;
            }

            _currentMovementMechanic.Rotate();
            _currentMovementMechanic.Move();
        }
    }
}

//Transfer to...
public enum MechanicType { None = -1, Axis, Mouse}

public abstract class BaseMovementMechanic
{
    public MechanicType Type { get; protected set; } = MechanicType.None;
    public bool IsInput => _input.IsInput();

    protected MovementController _movementController = null;

    protected NavMeshAgent _navMeshAgent = null;

    protected BaseInputOfMovement _input = null;

    public BaseMovementMechanic(MovementController controller)
    {
        _movementController = controller;
        _navMeshAgent = controller.NavMeshAgent;
    }

    public abstract void Move();
    public abstract void Rotate();

    public virtual void Stop() { }
}

public class MouseMovement : BaseMovementMechanic
{
    private Vector3 _targetPoint = Vector3.zero;

    public MouseMovement(MovementController controller) : base(controller) 
    {
        Type = MechanicType.Mouse;

        _input = controller.GetComponent<MouseInputOfMovement>();
    }

    public override void Move()
    {
        var point = _input.Read();

        if (_targetPoint != point)
        {
            if (_navMeshAgent.isStopped)
                _navMeshAgent.isStopped = false;

            _targetPoint = point;

            _navMeshAgent.SetDestination(_targetPoint);
        }
    }

    public override void Rotate() { }

    public override void Stop()
    {
        _navMeshAgent.isStopped = true;
    }
}

public class AxisMovement : BaseMovementMechanic
{
    private BasePlayer _player = null;

    public AxisMovement(MovementController controller) : base(controller)
    {
        Type = MechanicType.Axis;

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