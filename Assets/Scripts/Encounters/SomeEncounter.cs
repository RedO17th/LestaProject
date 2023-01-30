using System;
using UnityEngine;

public class SomeEncounter : BaseEncounter, ITaskEncounter, IInteractable
{
    [SerializeField] protected string _encounterName = string.Empty;

    [Header("Other settings")]
    [SerializeField] protected BasePointer _pointer;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    public string Name => _encounterName;

    protected GamePlayer _player = null;
    protected IQuestTask _task = null;


    protected virtual void Awake() { }

    public virtual void SetTask(IQuestTask task)
    {
        _task = task;
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
