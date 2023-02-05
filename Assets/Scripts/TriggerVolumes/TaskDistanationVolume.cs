using System;
using UnityEngine;

public class TaskDistanationVolume : BaseEncounter, ITaskEncounter
{
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    public IQuestTask Task => _questTask;

    protected IQuestTask _questTask = null;

    public virtual void SetTask(IQuestTask task) => _questTask = task;

    public void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(GamePlayer player) => SendSignalByContext();

    private void SendSignalByContext()
    {
        var context = new TaskContext();
            context.SetCommand(TaskCommand.Complete);
            context.SetID(Task.IDName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    public void Deactivate()
    {
        _triggerVolume.OnEnter -= PlayerCameUp;

        _triggerVolume.Disable();
    }
}