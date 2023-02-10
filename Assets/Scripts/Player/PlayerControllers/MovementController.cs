using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : BasePlayerContoller
{
    [SerializeField] private BaseMovementMechanic[] _movementMechanics = null;
    [SerializeField] private NavMeshAgent _navMeshAgent = null;

    //[Range(5f, 50f)]
    //[SerializeField] private float _speedRotation = 5f;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public PlayerDataContainer PlayerData => _playerData;
    public float NormalizedMovementSpeed
    {
        get 
        {
            var minSpeed = 0f;
            var maxSpeed = _playerData.RunSpeed;

            var currentSpeed = (float)(_currentMovementMechanic?.Speed);

            return (currentSpeed - minSpeed) / (maxSpeed - minSpeed);
        }
    }

    public PlayerDataContainer _playerData = null;
    private BaseMovementMechanic _currentMovementMechanic = null;

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);

        InitializeData();
        InitializeMovementMechanics();

        _currentMovementMechanic = _movementMechanics[0];
    }

    private void InitializeData()
    {
        var settingsSystem = ProjectSystem.GetSubSystem<SettingsSubSystem>();

        _playerData = settingsSystem.GetDataContainer<PlayerDataContainer>();
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

    #region Move part
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
    #endregion
}

//TODO: Transfer to...
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
