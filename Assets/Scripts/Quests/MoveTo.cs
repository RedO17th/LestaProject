using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MoveTo : BaseQuest
{
    [SerializeField] protected BaseTriggerVolume _triggerVolume;

    public override void Initialize(QuestSubSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare() => PrepareTriggerVolume();
    private void PrepareTriggerVolume()
    {
        _triggerVolume.Enable();
        _triggerVolume.OnEnter += ThePlayerCameUp;
    }

    private void ThePlayerCameUp(GamePlayer player) => CheckCompliting();

    public override void Launch() { }

    protected override bool CheckConditionOfCompliting() => true;

    public override void Complete()
    {
        ClearTriggerVolume();

        Debug.Log($"MoveTo.Complete");
    }

    private void ClearTriggerVolume()
    {
        _triggerVolume.OnEnter -= ThePlayerCameUp;
        _triggerVolume.Disable();
    }
}
