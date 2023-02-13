using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

//[TODO] Перевести общие поля с NPCEncounterWithDialog в EncounterWithDialog
public class BasePlayerAssistant : DialogueEncounter { }

public class Dog : BasePlayerAssistant
{
    private IStateMachine _stateMachine = null;

    protected override void Awake()
    {
        //_dialogController = GetComponent<BaseDialogController>();

        _stateMachine = GetComponent<AssistantStateMachine>();
        _stateMachine.Initialize(this);

        //_interactionHandler = new PlayerAssistantInteractionsController(this);
        //_interactionHandler.InitializeInteractionModes();
    }

    protected override void Start()
    {
        PrepareTriggerVolume();

        //_dialogController.Initialize();

        List<IState> states = new List<IState>()
        {
            new DefaultAssistantState(_stateMachine),
            new DialogueAssistantState(_stateMachine)
        };

        _stateMachine.SetStates(states);
    }

    public override void InitializeDialog(string dialogName)
    {
        //if (_dialogSubSystem == null)
        //    _dialogSubSystem = ProjectSystem.GetSubSystem<DialogSubSystem>();

        //var dialog = _dialogSubSystem.GetDialogueByName(dialogName);
        //    dialog.Initialize(this);

        //_dialogController.SetDialog(dialog);
    }

    public override void Hint() => base.Hint();
    public override void Activate() => base.Activate();

    public override void Interact()
    {
        Debug.Log($"Dog.Interact");

        _pointer.Disable();

        //_interactionHandler.Interact();
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


