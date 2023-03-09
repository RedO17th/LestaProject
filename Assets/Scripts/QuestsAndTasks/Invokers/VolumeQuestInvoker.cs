using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeQuestInvoker : QuestInvoker
{
    //[TODO] Transfer to BaseContextInvoker
    [SerializeField] protected bool _isEnabled = false;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume = null;

    protected virtual void Start() => Activate();
    public override void Activate() => ProcessEnable();

    protected virtual void ProcessEnable()
    {
        if (_isEnabled)
        {
            _triggerVolume.Enable();
            _triggerVolume.OnEnter += ProcessEnterInVolume;
        }
    }

    protected virtual void ProcessEnterInVolume(IPlayer obj)
    {
        Invoke();
        Deactivate();
    }

    protected override void ProcessInvoke() 
    {
        var context = new QuestContext();
            context.SetCommand(QuestCommand.Activate);
            context.SetID(_questID);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    protected override void Deactivate()
    {
        _triggerVolume.OnEnter -= ProcessEnterInVolume;
        _triggerVolume.Disable();

    }
}
