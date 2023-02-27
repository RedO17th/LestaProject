using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : DialogueEncounter
{
    private IStateMachine _stateMachine = null;

    protected override void Awake()
    {
        _stateMachine = GetComponent<GirlStateMachine>();
        _stateMachine.Initialize(this);

        var states = new List<IState>()
        {
            new DefaultGirlState(_stateMachine),
            new DialogueGirlState(_stateMachine)
        };

        _stateMachine.SetStates(states);
    }

    protected override void Start()
    {
        _stateMachine.ActivateDefaultBehaviour();
    }

    public override void InitializeDialog(string dialogName)
    {
        var s = _stateMachine.GetState<DialogueGirlState>();
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
}
