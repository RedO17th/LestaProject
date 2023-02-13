using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssistantInteractionsController : BaseInteractionsController
{
    public PlayerAssistantInteractionsController(IEncounter encounter) : base(encounter) { }

    public override void InitializeInteractionModes()
    {
        _interactions.Add(new PlayerAssistantSimpleInteractionMode(_encounter));
        _interactions.Add(new PlayerAssistantDialogueInteractionMode(_encounter));
    }
}

public class PlayerAssistantSimpleInteractionMode : BaseSimpleInteractionMode
{
    public PlayerAssistantSimpleInteractionMode(IEncounter encounter) : base(encounter) { }
    public override bool CheckConditionForExecution() => true;
    public override void Execute() { Debug.Log($"PlayerAssistantSimpleInteractionMode.Execute"); }
}

public class PlayerAssistantDialogueInteractionMode : BaseTaskInteractionMode
{
    private BasePlayerAssistant _playerAssistant = null;
    private BaseDialogController _dialogController = null;

    public PlayerAssistantDialogueInteractionMode(IEncounter encounter) : base(encounter)
    {
        _playerAssistant = _encounter as BasePlayerAssistant;

        //_dialogController = _playerAssistant.DialogController;
    }

    public override bool CheckConditionForExecution()
    {
        bool result = false;

        if (EncounterCanTalk())
            result = true;

        return result;
    }

    private bool EncounterCanTalk() => _playerAssistant.TaskIsExist && _dialogController.DialogIsExist;

    public override void Execute()
    {
        _dialogController.ActivateDialog();
    }
}