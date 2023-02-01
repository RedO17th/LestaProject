using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

//Перевести ли данную сущность в интерфейс?

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
        _dialogSubSystem = ProjectSystem.Instance.GetSubSystemByType(typeof(DialogSubSystem)) as DialogSubSystem;
        
        _dialogController = GetComponent<BaseDialogController>();
        _dialogController.Initialize(_dialogSubSystem);

        _interactionHandler = new PlayerAssistantInteractionsController(this);
        _interactionHandler.InitializeInteractionModes();
    }

    private void OnEnable()
    {
        PrepareTriggerVolume();
    }
    private void OnDisable()
    {
        ClearTriggerVolume();
    }

    public override void InitializeDialog(string dialogName)
    {
        var dialog = _dialogSubSystem.GetDialogueByName(dialogName);
        
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
}


