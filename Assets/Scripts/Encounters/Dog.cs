using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

//[TODO] Перевести общие поля с NPCEncounterWithDialog в EncounterWithDialog
public class BasePlayerAssistant : DialogueEncounter { }

public class Dog : BasePlayerAssistant
{
    protected override void Awake()
    {
        _dialogController = GetComponent<BaseDialogController>();

        _interactionHandler = new PlayerAssistantInteractionsController(this);
        _interactionHandler.InitializeInteractionModes();
    }

    protected override void Start()
    {
        PrepareTriggerVolume();

        _dialogController.Initialize();
    }

    public override void InitializeDialog(string dialogName)
    {
        if (_dialogSubSystem == null)
            _dialogSubSystem = ProjectSystem.GetSubSystem<DialogSubSystem>();

        var dialog = _dialogSubSystem.GetDialogueByName(dialogName);
            dialog.Initialize(this);

        _dialogController.SetDialog(dialog);
    }

    public override void Hint() => base.Hint();
    public override void Activate() => base.Activate();

    public override void Interact()
    {
        Debug.Log($"Dog.Interact");

        _pointer.Disable();

        _interactionHandler.Interact();
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


