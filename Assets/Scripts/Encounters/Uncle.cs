using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEncounterWithDialog : EncounterWithDialog
{
    public bool TaskIsExist => _task != null;

    public BaseDialogController DialogController => _dialogController;

    protected BaseInteractionsController _interactionHandler = null;

    protected DialogSubSystem _dialogSubSystem = null;
    protected BaseDialogController _dialogController = null;
}

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
        _dialogSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(DialogSubSystem)) as DialogSubSystem;

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
