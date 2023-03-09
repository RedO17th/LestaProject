using System;
using UnityEngine;

public class DistanationVolume : BaseTaskVolume
{
    public override void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(IPlayer player) => SendSignalByContext();

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