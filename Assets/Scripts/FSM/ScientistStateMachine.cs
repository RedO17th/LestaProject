using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistStateMachine : BaseStateMachine { }

public class DefaultScientistState : BaseState, IDefaultState
{
    private ScientistStateMachine _scientistStateMachine = null;

    public DefaultScientistState(IStateMachine stateMachine) : base(stateMachine)
    {
        _scientistStateMachine = stateMachine as ScientistStateMachine;
    }

    public override bool CanPerformAndNotActivated() => true;

    public override void Tick() { }
}

public class DialogueScientistState : DialogueState, IQuestState
{
    private ScientistStateMachine _scientistStateMachine = null;

    private bool _isStarted = false;

    public DialogueScientistState(IStateMachine stateMachine) : base(stateMachine)
    {
        _scientistStateMachine = stateMachine as ScientistStateMachine;
    }

    public override bool CanPerformAndNotActivated()
    {
        return _dialogueName != string.Empty && Activated == false;
    }

    public override void Tick()
    {
        base.Tick();

        ProcessTalk();
    }

    private void ProcessTalk()
    {
        if (_isStarted == false)
        {
            Activated = true;
            _isStarted = true;

            SendSignalByDialogueContext();
        }
    }

    private void SendSignalByDialogueContext()
    {
        var context = new DialogContext();
            context.SetCommand(DialogueCommand.Activate);
            context.SetID(_dialogueName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    public override void Stop() => ProcessCorrectEndOfDialogue();
    private void ProcessCorrectEndOfDialogue()
    {
        _dialogueName = string.Empty;

        OnStateCompleted(this);
    }

    //private void ProcessEndOfDialogue(BaseDialogue dialogue)
    //{
    //    if (dialogue.Name == _dialogueName)
    //    {
    //        if (dialogue.CorrectCompletion)
    //        {
    //            _dialogueName = string.Empty;
    //        }

    //        OnStateCompleted(this);
    //    }
    //}

    public override void Deactivate()
    {
        base.Deactivate();

        _isStarted = false;
    }
}