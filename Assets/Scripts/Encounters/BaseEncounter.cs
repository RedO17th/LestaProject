using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEncounter : MonoBehaviour, IEncounter
{
    [SerializeField] protected BasePointer _pointer;
    [SerializeField] protected BaseTriggerVolume _triggerVolume;

    //Test
    private void Awake()
    {
        Activate();
    }

    public virtual void Initialize(Component manager)
    { 
        
    }

    public virtual void Activate()
    {
        PrepareTriggerVolume();
    }

    protected virtual void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PrepareToInteraction;
        _triggerVolume.OnExit += CancelInteraction;
    }

    protected virtual void PrepareToInteraction() => _pointer.Enable();

    //Основной метод взаимодействия
    public virtual void Interact()
    {
        
    }

    protected virtual void CancelInteraction() => _pointer.Disable();

    public virtual void Deactivate()
    {
        ClearTriggerVolume();

        _pointer.Disable();
    }

    protected virtual void ClearTriggerVolume()
    {
        _triggerVolume.OnEnter -= PrepareToInteraction;
        _triggerVolume.OnExit -= CancelInteraction;

        _triggerVolume.Disable();
    }
}
