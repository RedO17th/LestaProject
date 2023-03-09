using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDialogueInvoker : DialogueInvoker
{
    [SerializeField] protected bool _isEnabled = false;

    protected ITriggerByPlayer _triggerVolumeByPlayer = null;

    private void Awake()
    {
        _triggerVolumeByPlayer = GetComponent<ITriggerByPlayer>();

        ProcessEnable();
    }

    public override void Activate()
    {
        _isEnabled = true;

        ProcessEnable();
    }

    protected virtual void ProcessEnable()
    {
        if (_isEnabled)
        {
            _isEnabled = true;

            _triggerVolumeByPlayer.Enable();
            _triggerVolumeByPlayer.OnEnter += ProcessEnterInVolume;
        }
    }

    protected virtual void ProcessEnterInVolume(IPlayer obj)
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
        _triggerVolumeByPlayer.OnEnter -= ProcessEnterInVolume;
        _triggerVolumeByPlayer.Disable();
    }
}
