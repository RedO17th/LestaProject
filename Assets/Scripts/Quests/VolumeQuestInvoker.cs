using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeQuestInvoker : QuestInvoker
{
    [SerializeField] private QuestSubSystem _questSubSystem;

    [SerializeField] private BaseTriggerVolume _triggerVolume = null;

    private void Awake()
    {
        _triggerVolume.Enable();
        _triggerVolume.OnEnter += ProcessEnterInVolume;
    }

    private void ProcessEnterInVolume(GamePlayer obj)
    {
        _triggerVolume.OnEnter -= ProcessEnterInVolume;
        _triggerVolume.Disable();

        Invoke();
    }

    protected override void ProcessInvoke() 
    {
        //_questSubSystem.SomeMeth(_questIDName);

        ProjectBus.Instance.SendSignalByContext(new QuestContext());
    }
}
