using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeQuestInvoker : QuestInvoker
{
    [SerializeField] protected bool _isEnabled = false;
    [SerializeField] protected TriggerVolumeByPlayer _triggerVolume = null;

    protected virtual void Awake()
    {
        ProcessEnable();
    }

    protected virtual void ProcessEnable()
    {
        if (_isEnabled)
        {
            _triggerVolume.Enable();
            _triggerVolume.OnEnter += ProcessEnterInVolume;
        }
    }

    protected virtual void ProcessEnterInVolume(GamePlayer obj)
    {
        _triggerVolume.OnEnter -= ProcessEnterInVolume;
        _triggerVolume.Disable();

        Invoke();
    }

    protected override void ProcessInvoke() 
    {
        var context = new QuestContext();
            context.SetIDName(_questIDName);

        ProjectBus.Instance.SendSignalByContext(context);
    }
}
