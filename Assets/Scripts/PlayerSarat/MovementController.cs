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
    [SerializeField] private float _speedMovement = 5f;
    [Range(5f, 25f)]
    [SerializeField] private float _speedRun = 5f;
    [Range(5f, 50f)]
    [SerializeField] private float _speedRotation = 5f;
    //..

    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private AnimatorController _animatorController = null;

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

    public override void Prepare()
    {
        _animatorController = _player.GetControllerBy(PlayerControllerType.Animator) as AnimatorController;
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

            //Можно возвращаться скорость из _currentMovementMechanic и передевать ее в _animatorController и в его Update передавать в дерево аниматора
        }
    }
}

//Transfer to...
public enum MechanicType { None = -1, AxisWalk, MouseWalk }

public abstract class BaseMovementMechanic : MonoBehaviour
{
    [SerializeField] private MechanicType _type = MechanicType.None;

    public MechanicType Type => _type;
    public bool IsInput => _input.IsInput();

    protected MovementController _movementController = null;

    protected NavMeshAgent _navMeshAgent = null;

    protected BaseInputOfMovement _input = null;

    public virtual void Initialize(BasePlayerContoller controller)
    {
        _movementController = controller as MovementController;
        _navMeshAgent = _movementController.NavMeshAgent;
    }

    public abstract void Move();
    public abstract void Rotate();

    public virtual void Stop() { }
}
