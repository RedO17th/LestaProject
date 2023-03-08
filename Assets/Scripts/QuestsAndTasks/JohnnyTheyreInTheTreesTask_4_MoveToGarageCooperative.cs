using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnnyTheyreInTheTreesTask_4_MoveToGarageCooperative : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    //[Remove]
    [Space]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected Vector3 _dogPosition = Vector3.zero;

    private ITaskVolumeEncounter _distanationVolume = null;

    //[Remove]
    private Dog _dog = null;

    public override void Prepare()
    {
        _distanationVolume = _quest.GetVolumeEncounterByName(_distanationVolumeName) as ITaskVolumeEncounter;
        _distanationVolume.SetTask(this);

        //Remove
        _dog = _quest.GetNpcEncounterByName(_dogEncounterName) as Dog;

        base.Prepare();
    }

    public override void Activate()
    {
        _distanationVolume.Activate();

        //Remove
        _dog.transform.position = _dogPosition;

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"JohnnyTheyreInTheTreesTask_4_MoveToGarageCooperative.Complete");

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
