using System;
using UnityEngine;

public interface IVolumeEncounter : IEncounter, ITaskable
{
    void Activate();
    void Deactivate();
}

public abstract class BaseVolumeEncounter : MonoBehaviour, IVolumeEncounter
{
    [SerializeField] protected string _name = string.Empty;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume = null;

    public string Name => _name;

    protected IQuestTask _questTask = null;

    public virtual void SetTask(IQuestTask task) { _questTask = task; }

    public virtual void Activate() { }
    public virtual void Deactivate() { }
}

public class DistanationVolume : BaseVolumeEncounter
{
    public override void Activate()
    {
        _triggerVolume.Enable();

        _triggerVolume.OnEnter += PlayerCameUp;
    }

    private void PlayerCameUp(BasePlayer player) => SendSignalByContext();

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