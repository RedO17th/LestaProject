using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_1_TalkWithAssistant : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected string _dogEncounterDialogName = string.Empty;

    private BasePlayerAssistant _dog = null;

    public override void Prepare()
    {
        _dog = _quest.GetNpcEncounterByName(_dogEncounterName) as BasePlayerAssistant;
        _dog.SetTask(this);
        _dog.InitializeDialog(_dogEncounterDialogName);
        _dog.Hint();

        base.Prepare();
    }

    public override void Activate() => base.Activate();

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_1_TalkWithAssistant.Complete");
    
        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _dog = null;
    }
}
 