using UnityEngine;

public class DistanationVolume : BaseConditionalQuestEntity
{
    [Space]
    [Header("Base settings")]
    [SerializeField] protected BaseTriggerVolume _triggerVolume;

    public override void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(GamePlayer player) => Complete();

    public override void Deactivate()
    {
        _triggerVolume.OnEnter -= PlayerCameUp;

        _triggerVolume.Disable();
    }
}