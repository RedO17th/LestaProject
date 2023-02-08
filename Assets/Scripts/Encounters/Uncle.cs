using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncle : NPCEncounterWithDialog
{
    protected override void Awake()
    {
        _dialogController = GetComponent<BaseDialogController>();

        _interactionHandler = new NPCEncounterInteractionsController(this);
        _interactionHandler.InitializeInteractionModes();
    }

    protected override void Start()
    {
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
        _pointer.Disable();

        _interactionHandler.Interact();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
