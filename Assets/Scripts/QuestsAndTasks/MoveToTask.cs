using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTask : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private ITaskEncounter _distanationVolumeEncounter = null;

    public override void Prepare()
    {
        _distanationVolumeEncounter = _quest.GetEncounterByName(_distanationVolumeName);
        _distanationVolumeEncounter.SetTask(this);
    
        base.Prepare();
    }

    public override void Activate()
    {
        _distanationVolumeEncounter.Activate();

        Debug.Log($"MoveToTask.Activate: {_name}");

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"MoveToTask.Complete: { _name }");

        base.Complete();
    }

    public override void Dectivate()
    {
        Debug.Log($"MoveToTask.Dectivate: {_name}");

        base.Dectivate();

        _distanationVolumeEncounter.Deactivate();

        Clear();
    }

    protected override void Clear()
    {
        _distanationVolumeEncounter = null;
    }
}
