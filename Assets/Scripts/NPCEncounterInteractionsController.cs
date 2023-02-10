using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEncounterInteractionsController : BaseInteractionsController
{
    public NPCEncounterInteractionsController(IEncounter encounter) : base(encounter) { }

    public override void InitializeInteractionModes()
    {
        _interactions.Add(new NPCEncounterSimpleInteractionMode(_encounter));
        _interactions.Add(new NPCEncounterDialogueInteractionMode(_encounter));
    }
}

public class NPCEncounterSimpleInteractionMode : BaseSimpleInteractionMode
{
    public NPCEncounterSimpleInteractionMode(IEncounter encounter) : base(encounter) { }

    public override bool CheckConditionForExecution() => true;
    public override void Execute() { Debug.Log($"NPCEncounterSimpleInteractionMode.Execute"); }
}

public class NPCEncounterDialogueInteractionMode : BaseTaskInteractionMode
{
    private DialogueEncounter _npcEncounter = null;
    private BaseDialogController _dialogController = null;

    public NPCEncounterDialogueInteractionMode(IEncounter encounter) : base(encounter)
    {
        _npcEncounter = _encounter as DialogueEncounter;

        _dialogController = _npcEncounter.DialogController;
    }

    public override bool CheckConditionForExecution()
    {
        bool result = false;

        if (EncounterCanTalk())
            result = true;

        return result;
    }

    private bool EncounterCanTalk() => _npcEncounter.TaskIsExist && _dialogController.DialogIsExist;

    public override void Execute()
    {
        _dialogController.ActivateDialog();
    }

}