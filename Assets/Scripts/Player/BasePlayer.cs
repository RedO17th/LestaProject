using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

//Возможно создать интерфейс IPlayer и объеденить его с IInteractor
public interface IInteractor
{
    void SetInteractable(IInteractable encounter);
    void RemoveInteractable(IInteractable encounter);
}

public class BasePlayer : MonoBehaviour, IInteractor
{
    [SerializeField] protected List<BasePlayerContoller> _controllers;

    #region Public Properties
    public HealthSign Health { get; } = new HealthSign(100);
    public EnergySign Energy { get; } = new EnergySign(150);
    //[Test]
    public Level Level { get; } = new Level();
    public Quaternion Rotation => transform.rotation;
    #endregion

    protected PlayerSubSystem _playerSystem = null;
    protected IInteractable _interactable = null;

    public virtual void Initialize(PlayerSubSystem system)
    {
        _playerSystem = system;

        InitializeControllers();
        PreparingControllers();
    }

    #region Systems part
    //Возможно все это дело необходимо вынести в PlayerSubSystem... А здесь только делегирование
    private void InitializeControllers()
    {
        foreach (var controller in _controllers)
            controller.Initialize(this);
    }

    private void PreparingControllers()
    {
        foreach (var controller in _controllers)
            controller.Prepare();
    }

    private void EnableControllers()
    {
        foreach (var controller in _controllers)
            controller.Enable();
    }
    private void DisableControllers()
    {
        foreach (var controller in _controllers)
            controller.Disable();
    }
    #endregion

    public void Activate()
    {
        EnableControllers();
    }

    public void Deactivate()
    {
        DisableControllers();
    }

    #region MovementPart
    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
    #endregion

    public T GetControllerBy<T>() where T : BasePlayerContoller
    {
        T controller = null;

        foreach (var c in _controllers)
        {
            if (c is T)
            {
                controller = c as T; 
                break;
            }
        }

        return controller;
    }

    #region Health part
    //TODO: Если не пригодится, то убрать...
    public virtual void SetDamage() { }

    #endregion

    #region Wallet part
    //TODO: Если не пригодится, то убрать...
    public virtual void AddPoints(int points)
    {
        _playerSystem.AddPoints(points);
    }

    #endregion

    #region Interaction part
    public void SetInteractable(IInteractable encounter)
    {
        _interactable = encounter;
    }
    public void RemoveInteractable(IInteractable encounter)
    {
        if(_interactable == encounter)
            _interactable = null;
    }
    #endregion

    private void Update()
    {
        if (_interactable != null && Input.GetKeyDown(KeyCode.E))
        {
            _interactable.Interact();
        }

        if (Input.GetKeyDown(KeyCode.Space)) Health.CurrentValue -= 10;
    }
}
