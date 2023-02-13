using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : DialogueEncounter
{
    protected override void Awake()
    {
        //_dialogController = GetComponent<BaseDialogController>();

        //_interactionHandler = new NPCEncounterInteractionsController(this);
        //_interactionHandler.InitializeInteractionModes();
    }

    protected override void Start()
    {
        //_dialogController.Initialize();
    }

    public override void InitializeDialog(string dialogName)
    {
        //if(_dialogSubSystem == null)
        //    _dialogSubSystem = ProjectSystem.GetSubSystem<DialogSubSystem>();

        //var dialog = _dialogSubSystem.GetDialogueByName(dialogName);
        //    dialog.Initialize(this);

        //_dialogController.SetDialog(dialog);
    }

    public override void Hint() => base.Hint();
    public override void Activate() => base.Activate();

    public override void Interact()
    {
        _pointer.Disable();

        //_interactionHandler.Interact();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }
}
