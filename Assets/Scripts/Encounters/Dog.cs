using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class BasePlayerAssistant : DialogueEncounter { }

public class Dog : BasePlayerAssistant
{
    private IStateMachine _stateMachine = null;

    protected override void Awake()
    {
        base.Awake();   

        _stateMachine = GetComponent<AssistantStateMachine>();
        _stateMachine.Initialize(this);

        var states = new List<IState>()
        {
            new DefaultAssistantState(_stateMachine),
            new DialogueAssistantState(_stateMachine)
        };

        _stateMachine.SetStates(states);
    }

    protected override void Start()
    {
        PrepareTriggerVolume();

        _stateMachine.ActivateDefaultBehaviour();
    }

    public override void InitializeDialog(string dialogName)
    {
        var s = _stateMachine.GetState<DialogueAssistantState>();
            s.SetDialogueName(dialogName);    
    }

    public override void Hint() => base.Hint();
    public override void Activate() => base.Activate();

    public override void Interact()
    {
        _pointer.Disable();

        _stateMachine.ActivateQuestBehaviour();
    }

    private void Update()
    {
        _stateMachine.Tick();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    private void OnDisable()
    {
        ClearTriggerVolume();
    }
}


