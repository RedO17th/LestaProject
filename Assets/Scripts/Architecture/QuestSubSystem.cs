using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestSubSystem : BaseSubSystem
{
    [SerializeField] private List<BaseQuest> _quests;

    private QuestContext _currentQuestContext = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeQuests();
    }
    private void InitializeQuests()
    {
        foreach (var quest in _quests)
            quest.Initialize(this);
    }

    public override void Prepare()
    {
        ProjectBus.Instance.OnQuestContextSignal += ProcessSignal;
    }

    #region Cycle of switching quests
    public override void StartSystem() { }

    private void ProcessSignal(QuestContext context)
    {
        _currentQuestContext = context;

        ActivateQuestByIDName();
    }

    private void ActivateQuestByIDName()
    {
        var quest = GetQuestByIDName(_currentQuestContext.IDName);
            quest?.Prepare();
            quest?.Activate();
    }

    private BaseQuest GetQuestByIDName(string name)
    {
        BaseQuest result = null;

        foreach (var quest in _quests)
        {
            if (quest.IDName == name)
            {
                result = quest;
                break;
            }
        }

        return result;
    }


    #endregion

    public override void Clear() { }
}
