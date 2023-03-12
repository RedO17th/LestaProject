using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistantStateMachine : BaseStateMachine
{
    private Dog _dogEncounter = null;

    public override void Initialize(IEncounter encounter)
    {
        base.Initialize(encounter);

        _dogEncounter = encounter as Dog;
    }

    public override void SetStates(List<IState> states)
    {
        base.SetStates(states);
    }
}

public class DefaultAssistantState : BaseState, IDefaultState
{
    private AssistantStateMachine _assistantStateMachine = null;

    public DefaultAssistantState(IStateMachine stateMachine) : base(stateMachine)
    {
        _assistantStateMachine = stateMachine as AssistantStateMachine;
    }

    public override bool CanPerformAndNotActivated() => true;

    public override void Tick() { }
}

public class DialogueAssistantState : DialogueState, IQuestState
{
    private AssistantStateMachine _assistantStateMachine = null;

    private bool _isStarted = false;

    public DialogueAssistantState(IStateMachine stateMachine) : base(stateMachine)
    {
        _assistantStateMachine = stateMachine as AssistantStateMachine;
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

    public override void SuccessfulStop() => ProcessCorrectEndOfDialogue();
    private void ProcessCorrectEndOfDialogue()
    {
        _dialogueName = string.Empty;

        OnStateCompleted(this);
    }

    public override void UnsuccessfulStop() => ProcessUnCorrectEndOfDialogue();
    private void ProcessUnCorrectEndOfDialogue()
    {
        OnStateCompleted(this);
    }

    //private void ProcessEndOfDialogue(BaseDialogue dialogue)
    //{
    //    if (dialogue.Name == _dialogueName)
    //    {
    //        //DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

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
