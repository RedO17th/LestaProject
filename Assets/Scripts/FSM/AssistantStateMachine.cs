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

    public override bool CanPerform() => true;

    public override Type Tick()
    {
        Debug.Log($"StandartAssistantState.Tick");

        return base.Tick();
    }
}

public class DialogueAssistantState : BaseState
{
    private AssistantStateMachine _assistantStateMachine = null;

    private bool _isStarted = false;
    private string _dialogName = string.Empty;

    public DialogueAssistantState(IStateMachine stateMachine) : base(stateMachine)
    {
        _assistantStateMachine = stateMachine as AssistantStateMachine;
    }

    public void SetDialogueName(string dialogName) => _dialogName = dialogName;

    public override Type Tick()
    {
        Debug.Log($"TalkAssistantState.Tick");

        ProcessTalk();

        return base.Tick();
    }

    private void ProcessTalk()
    {
        if (_isStarted == false)
        {
            _isStarted = true;

            var context = new DialogContext();
                context.SetCommand(DialogueCommand.Activate);
                context.SetID(_dialogName);

            ProjectBus.Instance.SendSignalByContext(context);
        }
    }
}
