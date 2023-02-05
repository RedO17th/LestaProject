using UnityEngine;

public class SimpleEncounter : BaseEncounter, IInteractable
{
    [SerializeField] protected BasePointer _pointer = null;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    protected GamePlayer _player = null;

    protected virtual void Awake() { }
    protected virtual void Start() { }

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
    }

    protected virtual void CancelInteraction(GamePlayer player)
    {
        _player.RemoveInteractable();
        _player = null;
    }

    protected virtual void ClearTriggerVolume()
    {
        _triggerVolume.OnEnter -= PrepareToInteraction;
        _triggerVolume.OnExit -= CancelInteraction;

        _triggerVolume.Disable();
    }
}
