using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

//[TODO] Перевести общие поля с NPCEncounterWithDialog в EncounterWithDialog
public class BasePlayerAssistant : EncounterWithDialog
{
    public bool TaskIsExist => _task != null;

    public BaseDialogController DialogController => _dialogController;

    protected BaseInteractionsController _interactionHandler = null;

    protected DialogSubSystem _dialogSubSystem = null;
    protected BaseDialogController _dialogController = null;
}

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

        _dialogSubSystem = ProjectSystem.GetSubSystem<DialogSubSystem>();

        _dialogController.Initialize(_dialogSubSystem);
    }

    public override void InitializeDialog(string dialogName)
    {
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


