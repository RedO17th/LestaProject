using System;
using UnityEngine;

public class TaskDistanationVolume : BaseEncounter, ITaskEncounter
{
    [SerializeField] protected string _encounterName = string.Empty;

    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume;

    public string Name => _encounterName;

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
            context.SetID(_questTask.IDName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    public void Deactivate()
    {
        _triggerVolume.OnEnter -= PlayerCameUp;

        _triggerVolume.Disable();
    }
}