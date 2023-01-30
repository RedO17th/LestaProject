using System;
using UnityEngine;

//Это "все" объекты с которыми мы можем взаимодействовать внутри конкретного Quest'a
//Очень маленький и базовый функционал - s_O_lid.
public abstract class BaseEncounter : MonoBehaviour, IEncounter
{
    [SerializeField] protected string _encounterName = string.Empty;

    public string Name => _encounterName;

    public abstract void SetTask(IQuestTask task);
    public abstract void Activate();
    public abstract void Deactivate();

}

public class Encounter : BaseEncounter, IInteractable
{
    [Header("Encounter settings")]
    [SerializeField] protected BasePointer _pointer;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    protected GamePlayer _player = null;
    protected IQuestTask _task = null;

    protected virtual void Awake() { }

    public override void SetTask(IQuestTask task)
    {
        _task = task;
    }

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
        _pointer.Enable();

        _player = player;
        _player.SetInteractable(this);
    }
   
    public virtual void Interact()
    {
        Debug.Log($"Encounter.Interact");

        _pointer.Disable();
    }

    protected virtual void CancelInteraction(GamePlayer player)
    {
        _pointer.Disable();

        _player.RemoveEncounter();
        _player = null;
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
