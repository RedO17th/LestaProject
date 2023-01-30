using System;
using UnityEngine;

public class TaskDistanationVolume : BaseEncounter
{
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    private IQuestTask _questTask = null;

    public override void SetTask(IQuestTask task)
    {
        _questTask = task;
    }

    public override void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(GamePlayer player) => SendSignalByContext();

    private void SendSignalByContext()
    {
        var context = new TaskContext();
            context.SetCommand(TaskCommand.Complete);
            context.SetID(_questTask.IDName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    public override void Deactivate()
    {
        _triggerVolume.OnEnter -= PlayerCameUp;

        _triggerVolume.Disable();
    }
}