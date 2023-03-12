using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : DialogueEncounter
{
    private IStateMachine _stateMachine = null;

    protected override void Awake()
    {
        base.Awake();

        _stateMachine = GetComponent<ScientistStateMachine>();
        _stateMachine.Initialize(this);

        var states = new List<IState>()
        {
            new DefaultScientistState(_stateMachine),
            new DialogueScientistState(_stateMachine)
        };

        _stateMachine.SetStates(states);
    }

    protected override void Start()
    {
        _stateMachine.ActivateDefaultBehaviour();
    }

    public override void InitializeDialog(string dialogName)
    {
        var s = _stateMachine.GetState<DialogueScientistState>();
            s.SetDialogueName(dialogName);
    }

    public override void StopDialogue()
    {
        var s = _stateMachine.GetState<DialogueScientistState>();
            s.Stop();
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
