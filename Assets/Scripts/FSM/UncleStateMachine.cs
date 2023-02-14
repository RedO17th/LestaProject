using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncleStateMachine : BaseStateMachine { }

public class DefaultUncleState : BaseState, IDefaultState
{
    private UncleStateMachine _uncleStateMachine = null;

    public DefaultUncleState(IStateMachine stateMachine) : base(stateMachine)
    {
        _uncleStateMachine = stateMachine as UncleStateMachine;
    }

    public override bool CanPerformAndNotActivated() => true;

    public override void Tick() { }
}

public class DialogueUncleState : DialogueState, IQuestState
{
    private AssistantStateMachine _assistantStateMachine = null;

    private bool _isStarted = false;

    public DialogueUncleState(IStateMachine stateMachine) : base(stateMachine)
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

            DialogueSceneController.OnDialogueEnd += ProcessEndOfDialogue;
        }
    }

    private void SendSignalByDialogueContext()
    {
        var context = new DialogContext();
            context.SetCommand(DialogueCommand.Activate);
            context.SetID(_dialogueName);

        ProjectBus.Instance.SendSignalByContext(context);
    }

    private void ProcessEndOfDialogue(BaseDialogue dialogue)
    {
        if (dialogue.Name == _dialogueName)
        {
            DialogueSceneController.OnDialogueEnd -= ProcessEndOfDialogue;

            OnStateCompleted(this);
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        _isStarted = false;
        _dialogueName = string.Empty;
    }
}