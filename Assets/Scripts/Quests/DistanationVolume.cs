using UnityEngine;

public class DistanationVolume : BaseEncounter
{
    [Space]
    [Header("Base settings")]
    [SerializeField] protected BaseTriggerVolume _triggerVolume;

    public override void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(GamePlayer player)
    {
        _questLink.Complete();
    }

    public override void Interact() { }

    public override void Deactivate()
    {
        _triggerVolume.OnEnter -= PlayerCameUp;

        _triggerVolume.Disable();
    }
}