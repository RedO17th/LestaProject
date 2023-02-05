using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_2_MoveToUncle : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _uncleEncounterName = string.Empty;
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private IHintableEncounter _uncle = null;
    private IVolumeEncounter _distanationVolume = null;

    public override void Prepare()
    {
        _distanationVolume = _quest.GetVolumeEncounterByName(_distanationVolumeName) as IVolumeEncounter;
        _distanationVolume.SetTask(this);

        _uncle = _quest.GetNpcEncounterByName(_uncleEncounterName) as IHintableEncounter;
        _uncle.Hint();

        base.Prepare();
    }

    public override void Activate()
    {
        _distanationVolume.Activate();
        _uncle.Activate();

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_2_MoveToUncle.Complete");

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
        _uncle = null;
    }
}
