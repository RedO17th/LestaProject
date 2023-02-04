using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_4_MoveToGarageCooperative : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private ITaskEncounter _distanationVolume = null;

    public override void Prepare()
    {
        _distanationVolume = _quest.GetEncounterByName(_distanationVolumeName) as ITaskEncounter;
        _distanationVolume.SetTask(this);

        base.Prepare();
    }

    public override void Activate()
    {
        _distanationVolume.Activate();

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_3_TalkWithUncleTask.Complete: {_name}");

        base.Complete();
    }

    public override void Dectivate()
    {
        base.Dectivate();

        _distanationVolume.Deactivate();

        Clear();
    }

    protected override void Clear()
    {
        _distanationVolume = null;
    }
}
