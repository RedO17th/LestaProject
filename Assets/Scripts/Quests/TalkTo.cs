using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTo : BaseQuest
{
    [SerializeField] protected List<BaseEncounter> _encounters;

    private int _numberOfUnCompletedEncounters = 0;

    public override void Initialize(QuestSubSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare()
    {
        InitializeEncounters();

        _numberOfUnCompletedEncounters = _encounters.Count;
    }

    private void InitializeEncounters()
    {
        foreach (var encounter in _encounters)
            encounter.Initialize(this);
    }

    public override void Launch()
    {
        ActivateEncounters();
    }

    private void ActivateEncounters()
    {
        foreach (var encounter in _encounters)
        {
            encounter.OnInteracted += CheckCompletedEncounter;
            encounter.Activate();
        }
    }

    private void CheckCompletedEncounter(BaseEncounter encounter)
    {
        encounter.OnInteracted -= CheckCompletedEncounter;

        CheckCompliting();
    }

    protected override bool CheckConditionOfCompliting()
    {
        _numberOfUnCompletedEncounters--;

        return _numberOfUnCompletedEncounters == 0 ? true : false;
    }

    public override void Complete()
    {
        Debug.Log($"TalkTo.Complete");

        DeactivateEncounters();
    }

    private void DeactivateEncounters()
    {
        foreach (var encounter in _encounters)
        {
            encounter.OnInteracted -= CheckCompletedEncounter;
            encounter.Deactivate();
        }
    }
}
