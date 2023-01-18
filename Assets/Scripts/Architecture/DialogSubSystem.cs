using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSubSystem : BaseSubSystem
{
    [SerializeField] private List<Encounter> _dialogEncounters;

    public event Action<BaseQuest> OnQuestActivated;

    private QuestSubSystem _questSubSystem = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare()
    {
        _questSubSystem = _projectSystem.GetSubSystemByType(typeof(QuestSubSystem)) as QuestSubSystem;
        _questSubSystem.OnQuestActivated += DefineQuestInDialogEncounters;

        InitializeDialogEncounters();
    }

    private void InitializeDialogEncounters()
    {
        foreach (var encounter in _dialogEncounters)
        {
            if (encounter is IDialogable dialogEncouner)
            {
                dialogEncouner.Initialize(this);
            }
        }
    }

    public override void StartSystem()
    {
        
        

    }

    private void DefineQuestInDialogEncounters(BaseQuest quest)
    {
        OnQuestActivated?.Invoke(quest);
    }

    public override void Clear()
    {
        _questSubSystem.OnQuestActivated -= DefineQuestInDialogEncounters;
        _questSubSystem = null;
    }
}
