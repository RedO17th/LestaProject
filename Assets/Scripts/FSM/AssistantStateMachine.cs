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

public class DefaultAssistantState : BaseState
{
    private AssistantStateMachine _assistantStateMachine = null;

    public DefaultAssistantState(IStateMachine stateMachine) : base(stateMachine)
    {
        _assistantStateMachine = stateMachine as AssistantStateMachine;
    }

    public override bool CanPerformAndNotActivated() => true;

    public override void Tick()
    {
        Debug.Log($"StandartAssistantState.Tick");
    }
}

public class DialogueAssistantState : DialogueState
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
        Debug.Log($"TalkAssistantState.Tick");

        ProcessTalk();
    }

    private void ProcessTalk()
    {
        if (_isStarted == false)
        {
            Activated = true;
            _isStarted = true;

            var context = new DialogContext();
                context.SetCommand(DialogueCommand.Activate);
                context.SetID(_dialogueName);

            ProjectBus.Instance.SendSignalByContext(context);
        }
    }
}
