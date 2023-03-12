using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncle : DialogueEncounter
{
    private IStateMachine _stateMachine = null;

    protected override void Awake()
    {
        base.Awake();

        _stateMachine = GetComponent<UncleStateMachine>();
        _stateMachine.Initialize(this);

        var states = new List<IState>()
        {
            new DefaultUncleState(_stateMachine),
            new DialogueUncleState(_stateMachine)
        };

        _stateMachine.SetStates(states);
    }

    protected override void Start()
    {
        _stateMachine.ActivateDefaultBehaviour();
    }

    public override void InitializeDialog(string dialogName)
    {
        var s = _stateMachine.GetState<DialogueUncleState>();
            s.SetDialogueName(dialogName);
    }
    public override void SuccessfulCompletionOfTheDialogue()
    {
        var s = _stateMachine.GetState<DialogueUncleState>();
            s.SuccessfulStop();
    }
    public override void UnsuccessfulCompletionOfTheDialog()
    {
        var s = _stateMachine.GetState<DialogueUncleState>();
            s.UnsuccessfulStop();
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
}
