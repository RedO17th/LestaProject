using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWithDogTask : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected string _dogEncounterDialogName = string.Empty;

    //[ForMe] Для расширения функционала сделать тип = Dog, или добавить абстракцию "Помощника"? 
    private BasePlayerAssistant _dog = null;

    public override void Prepare()
    {
        _dog = _quest.GetEncounterByName(_dogEncounterName) as BasePlayerAssistant;
        _dog.SetTask(this);
        _dog.InitializeDialog(_dogEncounterDialogName);

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
        _dog = null;
    }
}
