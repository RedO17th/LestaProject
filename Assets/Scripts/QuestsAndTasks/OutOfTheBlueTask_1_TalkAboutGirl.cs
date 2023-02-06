using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTheBlueTask_1_TalkAboutGirl : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _girlName = string.Empty;
    [SerializeField] protected string _dialogueName = string.Empty;

    private IDialogableEncounter _girl = null;

    public override void Prepare()
    {
        _girl = _quest.GetNpcEncounterByName(_girlName) as IDialogableEncounter;
        _girl.SetTask(this);
        _girl.InitializeDialog(_dialogueName);

        base.Prepare();
    }

    public override void Activate()
    {
        _girl.Activate();

        base.Activate();

        //PerformForcedTermination();
    }

    //private void PerformForcedTermination()
    //{
    //    _context = new TaskContext();
    //    _context.SetCommand(TaskCommand.Complete);
    //    _context.SetID(_idName);

    //    ProcessCommandFromSignal();
    //}

    protected override void Complete()
    {
        Debug.Log($"OutOfTheBlueTask_1_TalkAboutGirl.Complete");

        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        Clear();
    }

    protected override void Clear()
    {
        _girl = null;
    }
}
