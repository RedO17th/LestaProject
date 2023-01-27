using System;
using UnityEngine;

public class QuestDistanationVolume : BaseEncounter, INameble
{
    [SerializeField] protected string _encounterName = string.Empty;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    public string Name => _encounterName;

    public event Action OnDestinationReached;

    public override void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(GamePlayer player)
    {
        OnDestinationReached?.Invoke();
    }

    public override void Deactivate()
    {
        _triggerVolume.OnEnter -= PlayerCameUp;

        _triggerVolume.Disable();
    }
}