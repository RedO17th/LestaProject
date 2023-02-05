using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDialogueInvoker : DialogueInvoker
{
    [SerializeField] protected bool _isEnabled = true;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume = null;

    public override void Activate() => ProcessEnable();

    protected virtual void ProcessEnable()
    {
        if (_isEnabled == false)
        {
            _isEnabled = true;

            _triggerVolume.Enable();
            _triggerVolume.OnEnter += ProcessEnterInVolume;
        }
    }

    protected virtual void ProcessEnterInVolume(GamePlayer obj)
    {
        Invoke();
        Deactivate();
    }

    protected override void ProcessInvoke()
    {
        var context = new DialogContext();
            context.SetCommand(DialogueCommand.Activate);
            context.SetID(_dialogueName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    protected override void Deactivate()
    {
        _triggerVolume.OnEnter -= ProcessEnterInVolume;
        _triggerVolume.Disable();
    }
}
