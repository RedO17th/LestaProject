using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestSubSystem : BaseSubSystem
{
    [SerializeField] private List<BaseQuest> _quests;

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
        ProjectBus.Instance.OnSignal += ProcessSignal;
    }

    #region Cycle of switching quests
    public override void StartSystem() { }

    private void ProcessSignal(SignalContext context)
    {
        if (IsTheQuestContext(context))
        {
            ActivateQuestByIDName("ID");
        }
    }

    private bool IsTheQuestContext(SignalContext context)
    {
        return context.Type == typeof(QuestContext);
    }

    private void ActivateQuestByIDName(string name)
    {
        var quest = GetQuestByIDName(name);
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
