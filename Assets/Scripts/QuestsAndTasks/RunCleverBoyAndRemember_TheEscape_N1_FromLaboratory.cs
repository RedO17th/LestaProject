using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCleverBoyAndRemember_TheEscape_N1_FromLaboratory : BaseQuestTask
{
    [Space]
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private ITaskVolumeEncounter _distanationVolume = null;

    #region ToRemove
    [Space]
    [SerializeField] protected string _dogEncounterName = string.Empty;
    [SerializeField] protected Vector3 _dogPosition = Vector3.zero;
    private Dog _dog = null;

    [Space]
    [SerializeField] protected string _girlEncounterName = string.Empty;
    [SerializeField] protected Vector3 _girlPosition = Vector3.zero;
    private Girl _girl = null;

    [Space]
    [SerializeField] protected string _scientistEncounterName = string.Empty;
    [SerializeField] protected Vector3 _scientistPosition = Vector3.zero;
    #endregion

    private Scientist _scientist = null;

    public override void Prepare()
    {
        _distanationVolume = _quest.GetVolumeEncounterByName(_distanationVolumeName) as ITaskVolumeEncounter;
        _distanationVolume.SetTask(this);

        //[TODO] Remove
        _dog = _quest.GetNpcEncounterByName(_dogEncounterName) as Dog;
        _scientist = _quest.GetNpcEncounterByName(_scientistEncounterName) as Scientist;
        _girl = _quest.GetNpcEncounterByName(_girlEncounterName) as Girl;
        //..

        base.Prepare();
    }

    public override void Activate()
    {
        base.Activate();

        _distanationVolume.Activate();

        //Remove
        _dog.transform.position = _dogPosition;
        _girl.transform.position = _girlPosition;
        _scientist.transform.position = _scientistPosition;
        //..
    }

    protected override void Complete()
    {
        Debug.Log($"RunCleverBoyAndRemember_TheEscape_N1.Complete");

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
