using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndPreserveQuest_1_MoveToScientistLaboratory : BaseQuestTask
{
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private ITaskVolumeEncounter _distanationVolume = null;

    //[Remove]
    [Space]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected Vector3 _dogPosition = Vector3.zero;
    private Dog _dog = null;

    [Space]
    [SerializeField] protected string _girlEncounterName = string.Empty;
    [SerializeField] protected Vector3 _girlPosition = Vector3.zero;
    private Girl _girl = null;
    //..

    public override void Initialize(BaseQuest quest)
    {
        base.Initialize(quest);
    }

    public override void Prepare()
    {
        _distanationVolume = _quest.GetVolumeEncounterByName(_distanationVolumeName) as ITaskVolumeEncounter;
        _distanationVolume.SetTask(this);

        //[Remove]
        _dog = _quest.GetNpcEncounterByName(_dogEncounterName) as Dog;
        _girl = _quest.GetNpcEncounterByName(_girlEncounterName) as Girl;
        //..

        base.Prepare();
    }

    public override void Activate()
    {
        _distanationVolume.Activate();

        //Remove
        _dog.transform.position = _dogPosition;
        _girl.transform.position = _girlPosition;
        //..

        base.Activate();
    }

    protected override void Complete()
    {
        Debug.Log($"SaveAndPreserveQuest_1_MoveToScientistLaboratory.Complete");

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

        //..
        _girl = null;
        _dog = null;
    }
}
