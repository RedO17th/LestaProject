using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVolume : FunctionalTriggerVolume
{
    [SerializeField] private BasePointer _pointer = null;
    [SerializeField] private Transform _teleportPoint = null;

    private IPlayer _teleportable = null;

    protected override void Awake() 
    {
        base.Awake();
    }
    protected override void Start() { }

    [ContextMenu("ActivateTeleport")]
    private void ActivateTeleport() => Activate();

    public override void Activate() 
    {
        base.Activate();
    }

    protected override void ProcessingEnter(Collider other)
    {
        _teleportable = other.attachedRigidbody.GetComponent<IPlayer>();

        if (_teleportable != null)
        {
            _pointer.Enable();
            _teleportable.SetInteractable(this);
        }
    }

    protected override void ProcessingExit(Collider other) 
    {
        var teleportable = other.attachedRigidbody.GetComponent<IPlayer>();

        if (teleportable != null && teleportable == _teleportable)
        {
            _pointer.Disable();
            _teleportable.RemoveInteractable(this);
            _teleportable = null;
        }
    }

    public override void Interact() => ProcessTeleport();
    private void ProcessTeleport()
    {
        if (_teleportable != null)
        {
            Debug.Log($"ProcessTeleport: { _teleportPoint.position } ");

            _teleportable.TeleportTo(_teleportPoint.position);
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        Clear();
    }

    protected override void Clear()
    {
        _teleportable = null;
    }
}
