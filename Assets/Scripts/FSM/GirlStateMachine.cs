using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlStateMachine : BaseStateMachine { }

public class DefaultGirlState : BaseState, IDefaultState
{
    private GirlStateMachine _girlStateMachine = null;

    public DefaultGirlState(IStateMachine stateMachine) : base(stateMachine)
    {
        _girlStateMachine = stateMachine as GirlStateMachine;
    }

    public override bool CanPerformAndNotActivated() => true;

    public override void Tick() { }
}

public class DialogueGirlState : DialogueState, IQuestState
{
    private GirlStateMachine _girlStateMachine = null;

    private bool _isStarted = false;

    public DialogueGirlState(IStateMachine stateMachine) : base(stateMachine)
    {
        _girlStateMachine = stateMachine as GirlStateMachine;
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

            if (dialogue.CorrectCompletion)
            {
                _dialogueName = string.Empty;
            }

            OnStateCompleted(this);
        }
    }

    public override void Deactivate()
    {
        base.Deactivate();

        _isStarted = false;
    }
}