using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWithDogTask : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dogEncounterName = string.Empty;

    private IDialogableEncounter _dogEncounter = null;

    public override void Prepare()
    {
        _dogEncounter = _quest.GetEncounterByName(_dogEncounterName) as IDialogableEncounter;
        _dogEncounter.SetTask(this);
        _dogEncounter.InitializeDialog();

        base.Prepare();
    }

    public override void Activate()
    {
        Debug.Log($"TalkWithDogTask.Activate: {_name}");

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"TalkWithDogTask.Complete: {_name}");

        base.Complete();
    }

    public override void Dectivate()
    {
        Debug.Log($"TalkWithDogTask.Dectivate: {_name}");

        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _dogEncounter = null;
    }
}
