using System;
using UnityEngine;

public class SimpleEncounter : BaseEncounter, IInteractable
{
    [SerializeField] protected BasePointer _pointer = null;

    public event Action OnPlayerCameUp;
    public event Action OnPlayerMovedAway;

    protected ITriggerByPlayer _triggerVolume = null;

    protected IPlayer _player = null;

    protected virtual void Awake() 
    {
        _triggerVolume = GetComponent<ITriggerByPlayer>();
    }

    protected virtual void Start() { }

    protected virtual void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PrepareToInteraction;
        _triggerVolume.OnExit += CancelInteraction;
    }

    protected virtual void PrepareToInteraction(IPlayer player)
    {
        _player = player;
        _player.SetInteractable(this);

        OnPlayerCameUp?.Invoke();
    }

    public virtual void Interact()
    {
        Debug.Log($"SimpleEncounter.Interact");
    }

    protected virtual void CancelInteraction(IPlayer player)
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
