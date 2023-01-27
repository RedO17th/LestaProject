using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuestTask : BaseQuestTask
{
    [Header("Encounter names")]
    [SerializeField] protected string _distanationVolumeName = string.Empty;

    private QuestDistanationVolume _distanationVolume = null;

    public override void Prepare()
    {
        _distanationVolume = _quest.GetEncounterByName(_distanationVolumeName) as QuestDistanationVolume;
        _distanationVolume.OnDestinationReached += ProcessDestinationReaching;
    }

    public override void Activate()
    {
        _distanationVolume.Activate();

        Debug.Log($"TestQuestTask.Activate: {_name}");

        base.Activate();
    }

    private void ProcessDestinationReaching()
    {
        ProcessCorrectCompletion();
    }

    protected override void Complete()
    {
        Debug.Log($"TestQuestTask.Complete: { _name }");

        base.Complete();
    }

    public override void Dectivate()
    {
        Debug.Log($"TestQuestTask.Dectivate: {_name}");

        _distanationVolume.OnDestinationReached -= ProcessDestinationReaching;
        _distanationVolume.Deactivate();

        Clear();
    }

    protected override void Clear()
    {
        _distanationVolume = null;
    }
}
