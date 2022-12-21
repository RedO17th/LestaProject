using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [SerializeField] private Animator _aController = null;
    [SerializeField] private List<BasePlayerContoller> _controllers;

    #region Public Properties
    public Quaternion Rotation => transform.rotation;
    #endregion

    private CharacterController _characterController = null;
    
    private void Awake()
    {
        Initialize();
        InitializeControllers();

    }

    public void Initialize()
    {
        _characterController = GetComponent<CharacterController>();
    }

    #region Systems part
    private void InitializeControllers()
    {
        foreach (var controller in _controllers)
            controller.Initialize(this);
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
        return _controllers.Where(c => c.Type == type) as BasePlayerContoller;
    }
    #endregion

    public void Activate()
    {
        EnableControllers();
    }

    #region MovementPart
    public void Move(Vector3 way)
    {
        _characterController.Move(way);
    }
    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
    #endregion

    public void Deactivate() 
    {
        DisableControllers();
    }

    public void SetDamage()
    { 
        
    }
}
