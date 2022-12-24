using System;
using System.Collections;
using System.Collections.Generic;
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

    //private BaseMovementMechanic _currentMovementMechanic = null;
    //private BaseMovementMechanic _currentMovementMechanic = null;
    //private BaseMovementMechanic[] _movementMechanics = null;

    private BaseMovementMechanic _mouseMovement = null;
    private BaseMovementMechanic _axisMovement = null;

    private Vector3 _direction = Vector3.zero;

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);

        //_movementMechanics = new BaseMovementMechanic[]
        //{
        //    new MouseMovement(this),
        //    new AxisMovement(this)
        //};

        _mouseMovement = new MouseMovement(this);
        _axisMovement = new AxisMovement(this);
    }

    void Update()
    {
        //if (_currentMovementMechanic.IsInput)
        //    _currentMovementMechanic.Move();

        if (_axisMovement.IsInput)
        {
            _mouseMovement.Stop();
            _axisMovement.Move(Time.deltaTime);
        }

        if (_mouseMovement.IsInput)
        {
            _mouseMovement.Move(Time.deltaTime);
        }

    }

    private void ProcessingMovement() { }
    private void ProcessingRotation()
    {
        var directionRotation = new Vector3(_direction.x, 0f, _direction.z);
        if (directionRotation.magnitude != 0f)
        {
            var rotation = Quaternion.LookRotation(directionRotation);
            var targetRotation = Quaternion.Slerp(_player.Rotation, rotation, Time.deltaTime * _speedRotation);

            _player.Rotate(targetRotation);
        }
    }
}

public abstract class BaseMovementMechanic
{
    public bool IsInput => _input.IsInput();

    protected MovementController _movementController = null;
    protected NavMeshAgent _navMeshAgent = null;

    protected BaseInputOfMovement _input = null;

    public BaseMovementMechanic(MovementController controller)
    {
        _movementController = controller;
        _navMeshAgent = controller.NavMeshAgent;
    }

    public virtual void Move(float deltaTime)
    {
        if (_navMeshAgent.isStopped)
            _navMeshAgent.isStopped = false;
    }

    public virtual void Stop() { }
}

public class MouseMovement : BaseMovementMechanic
{
    public MouseMovement(MovementController controller) : base(controller) 
    {
        _input = new MouseInputOfMovement();
    }

    public override void Move(float deltaTime)
    {
        base.Move(deltaTime);

        _navMeshAgent.SetDestination(_input.Read());
    }

    public override void Stop()
    {
        _navMeshAgent.isStopped = true;
    }
}

public class AxisMovement : BaseMovementMechanic
{
    public AxisMovement(MovementController controller) : base(controller)
    {
        _input = new AxisInputOfMovement();
    }

    public override void Move(float deltaTime)
    {
        _navMeshAgent.Move(_input.Read() * deltaTime);
    } 
}
