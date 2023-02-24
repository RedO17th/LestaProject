using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseInputOfMovement : MonoBehaviour
{
    protected MainInputComponent _playerInputComponent { get; private set; } = null;

    protected virtual void Awake()
    {
        _playerInputComponent = new MainInputComponent();
    }

    protected virtual void OnEnable()
    {
        _playerInputComponent.Enable();
    }

    protected virtual void OnDisable()
    {
        _playerInputComponent.Disable();
    }

    public abstract bool IsInput();
    public abstract Vector3 Read(); 
}