using System;
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
    //�������� ��� ��� ���� ���������� ������� � PlayerSubSystem... � ����� ������ �������������
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

    //�������������� ��� �������������...

    #endregion

    //Interact part (test)
    //[ForMe] � ������ ���� ����� ���������� encounter'a... ��������... �� Event?

    private IInteractable _interactable = null;
    public void SetInteractable(IInteractable encounter)
    {
        _interactable = encounter;
    }
    public void RemoveInteractable()
    {
        _interactable = null;
    }

    private void Update()
    {
        if (_interactable != null && Input.GetKeyDown(KeyCode.E))
        {
            _interactable.Interact();
        }
    }
}
