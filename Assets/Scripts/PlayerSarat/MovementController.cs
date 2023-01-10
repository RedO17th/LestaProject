using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MovementController : BasePlayerContoller
{
    [SerializeField] private BaseMovementMechanic[] _movementMechanics = null;
    [SerializeField] private NavMeshAgent _navMeshAgent = null;

    //TODO: Transfer to Settings system
    [Range(5f, 25f)]
    [SerializeField] private float _walkSpeed = 5f;
    [Range(5f, 25f)]
    [SerializeField] private float _runSpeed = 5f;
    [Range(5f, 50f)]
    [SerializeField] private float _speedRotation = 5f;
    //..

    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public float WalkSpeed => _walkSpeed;
    public float RunSpeed => _runSpeed;
    public float NormalizedMovementSpeed
    {
        get 
        {
            var minSpeed = 0f;
            var maxSpeed = _runSpeed;

            var currentSpeed = (float)(_currentMovementMechanic?.Speed);

            return (currentSpeed - minSpeed) / (maxSpeed - minSpeed);
        }
    }

    private BaseMovementMechanic _currentMovementMechanic = null;

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);

        InitializeMovementMechanics();

        _currentMovementMechanic = _movementMechanics[0];
    }

    private void InitializeMovementMechanics()
    {
        foreach (var mech in _movementMechanics)
            mech.Initialize(this);
    }

    public override void Prepare() { }

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
            //if (mech.IsInput)
            //    return mech;

            if (mech.IsInput)
                mechanic = mech;
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
        else
        {
            _currentMovementMechanic.Stop();
        }
    }
}

//Transfer to...
public enum MechanicType { None = -1, AxisWalk, MouseWalk, AxisRun, MouseRun }

public abstract class BaseMovementMechanic : MonoBehaviour
{
    [SerializeField] private MechanicType _type = MechanicType.None;

    public MechanicType Type => _type;
    public bool IsInput => _input.IsInput();
    public float Speed => _currentSpeed;

    protected MovementController _movementController = null;

    protected NavMeshAgent _navMeshAgent = null;

    protected BaseInputOfMovement _input = null;

    protected float _currentSpeed = 0f;

    public virtual void Initialize(BasePlayerContoller controller)
    {
        _movementController = controller as MovementController;
        _navMeshAgent = _movementController.NavMeshAgent;
    }

    public virtual void Move() { }

    public abstract void Rotate();

    public virtual void Stop() { _currentSpeed = 0f; }
}
