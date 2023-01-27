using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePlayer : BasePlayer
{
    [SerializeField] private List<BasePlayerContoller> _controllers;

    #region Public Properties
    public Quaternion Rotation => transform.rotation;
    #endregion

    public override void Initialize(PlayerSubSystem system)
    {
        base.Initialize(system);

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

    public BasePlayerContoller GetControllerBy(PlayerControllerType type)
    {
        BasePlayerContoller pController = null;

        foreach (var controller in _controllers)
        {
            if (controller.Type == type)
            {
                pController = controller;
                break;
            }
        }

        return pController;
    }
    #endregion

    public void Activate()
    {
        EnableControllers();
    }

    #region MovementPart
    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
    #endregion

    public void Deactivate()
    {
        DisableControllers();
    }

    #region Wallet part

    //Переопределить при необходимости...

    #endregion

    //Interact part (test)

    private Encounter _encounter = null;

    //А вообще есть смысл передавать encounter'a...
    public void SetEncounter(Encounter encounter)
    {
        _encounter = encounter;
    }

    private void Update()
    {
        if (_encounter != null && Input.GetKeyDown(KeyCode.E))
        {
            _encounter.Interact();
        }
    }

    public void RemoveEncounter()
    {
        _encounter = null;
    }


}
