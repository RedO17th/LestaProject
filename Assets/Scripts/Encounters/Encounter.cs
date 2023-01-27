using System;
using UnityEngine;

//Это "все" объекты с которыми мы можем взаимодействовать внутри конкретного Quest'a
//Очень маленький и базовый функционал - s_O_lid.
public abstract class BaseEncounter : MonoBehaviour, IEncounter
{
    public abstract void Activate();
    public abstract void Deactivate();
}

public class Encounter : BaseEncounter, IInteractable
{
    [Space]
    [Header("Encounter settings")]
    [SerializeField] protected BasePointer _pointer;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    protected GamePlayer _player = null;

    protected virtual void Awake() { }

    public override void Activate() 
    {
        PrepareTriggerVolume();
    }

    protected virtual void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PrepareToInteraction;
        _triggerVolume.OnExit += CancelInteraction;
    }

    protected virtual void PrepareToInteraction(GamePlayer player)
    {
        //TODO: Прокинуть все обоюдные ссылки...
        _player = player;
        _player.SetEncounter(this);

        _pointer.Enable();
    }
   
    public virtual void Interact()
    {
        Debug.Log($"Encounter.Interact");

        _pointer.Disable();
    }

    protected virtual void CancelInteraction(GamePlayer player)
    {
        if (_player == player)
        {
            //TODO: Отчистить все обоюдные ссылки...
            _player.RemoveEncounter();
            _player = null;

            _pointer.Disable();
        }
    }

    public override void Deactivate()
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
