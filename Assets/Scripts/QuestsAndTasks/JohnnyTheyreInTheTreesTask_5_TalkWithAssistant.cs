using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_5_TalkWithAssistant : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dialogueInvokerVolumeName = string.Empty;

    private BaseContextInvoker _dialogueInvokerVolume = null;

    public override void Prepare()
    {
        _dialogueInvokerVolume = _quest.GetEncounterByName(_dialogueInvokerVolumeName) as BaseContextInvoker;

        base.Prepare();
    }

    public override void Activate()
    {
        _dialogueInvokerVolume.Activate();

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_5_TalkWithAssistant.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _dialogueInvokerVolume = null;
    }
}
