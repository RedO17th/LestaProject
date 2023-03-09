using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndPreserveQuest_2_TeleportToScientistLaboratory : BaseQuestTask
{
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private ITaskVolumeEncounter _distanationVolume = null;

    public override void Prepare()
    {
        _distanationVolume = _quest.GetVolumeEncounterByName(_distanationVolumeName) as ITaskVolumeEncounter;
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
        Debug.Log($"SaveAndPreserveQuest_2_TeleportToScientistLaboratory.Complete");

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
