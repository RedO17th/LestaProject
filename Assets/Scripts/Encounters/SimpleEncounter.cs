﻿using UnityEngine;

public class SimpleEncounter : BaseEncounter, IInteractable
{
    [SerializeField] protected string _name = string.Empty;

    [SerializeField] protected BasePointer _pointer = null;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    protected GamePlayer _player = null;

    protected virtual void Awake() { }

    protected virtual void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PrepareToInteraction;
        _triggerVolume.OnExit += CancelInteraction;
    }

    protected virtual void PrepareToInteraction(GamePlayer player)
    {
        _player = player;
        _player.SetInteractable(this);
    }

    public virtual void Interact()
    {
        Debug.Log($"SimpleEncounter.Interact");

        _pointer.Disable();
    }

    protected virtual void CancelInteraction(GamePlayer player)
    {
        _pointer.Disable();

        _player.RemoveEncounter();
        _player = null;
    }

    protected virtual void ClearTriggerVolume()
    {
        _triggerVolume.OnEnter -= PrepareToInteraction;
        _triggerVolume.OnExit -= CancelInteraction;

        _triggerVolume.Disable();
    }
}
