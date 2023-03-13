using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCleverBoyAndRemember_TheEscape_N2 : BaseQuestTask
{
    [Space]
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
        base.Activate();

        _distanationVolume.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"RunCleverBoyAndRemember_TheEscape_N2.Complete");

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
