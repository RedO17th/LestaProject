using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTheBlueTask_1_TalkWithAssistant : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dialogueInvokerVolumeName = string.Empty;

    private IContextInvoker _dialogueInvokerVolume = null;

    public override void Prepare()
    {
        _dialogueInvokerVolume = _quest.GetInvokerEncounterByName(_dialogueInvokerVolumeName) as IContextInvoker;
    }

    public override void Activate()
    {
        _dialogueInvokerVolume.Activate();

        base.Activate();

        PerformForcedTermination();
    }

    private void PerformForcedTermination()
    {
        _context = new TaskContext();
        _context.SetCommand(TaskCommand.Complete);
        _context.SetID(_idName);

        ProcessCommandFromSignal();
    }

    protected override void Complete()
    {
        Debug.Log($"OutOfTheBlueTask_1_TalkWithAssistant.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        Clear();
    }

    protected override void Clear()
    {
        _dialogueInvokerVolume = null;
    }
}
