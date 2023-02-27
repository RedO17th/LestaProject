using System;
using UnityEngine;

public class SimpleEncounter : BaseEncounter, IInteractable
{
    [SerializeField] protected BasePointer _pointer = null;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    public event Action OnPlayerCameUp;
    public event Action OnPlayerMovedAway;

    protected BasePlayer _player = null;

    protected virtual void Awake() { }
    protected virtual void Start() { }

    protected virtual void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PrepareToInteraction;
        _triggerVolume.OnExit += CancelInteraction;
    }

    protected virtual void PrepareToInteraction(BasePlayer player)
    {
        _player = player;
        _player.SetInteractable(this);

        OnPlayerCameUp?.Invoke();
    }

    public virtual void Interact()
    {
        Debug.Log($"SimpleEncounter.Interact");
    }

    protected virtual void CancelInteraction(BasePlayer player)
    {
        _player.RemoveInteractable(this);
        _player = null;

        OnPlayerMovedAway?.Invoke();
    }

    protected virtual void ClearTriggerVolume()
    {
        _triggerVolume.OnEnter -= PrepareToInteraction;
        _triggerVolume.OnExit -= CancelInteraction;

        _triggerVolume.Disable();
    }
}
