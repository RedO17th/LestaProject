using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestSubSystem : BaseSubSystem
{
    [SerializeField] private List<BaseQuest> _quests;

    private QuestContext _questContext = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);
    }

    public override void Prepare()
    {
        ProjectBus.Instance.OnQuestContextSignal += ProcessSignal;
    }

    #region Cycle of switching quests
    public override void StartSystem() { }

    private void ProcessSignal(QuestContext context)
    {
        _questContext = context;

        ProcessCommandFromSignal();
    }

    //[TODO] Описать менеджеров в соответствии с командами
    private void ProcessCommandFromSignal()
    {
        switch (_questContext.Command)
        {
            case QuestCommand.Open: 
            case QuestCommand.Close:
            case QuestCommand.Deactivate:
            case QuestCommand.Complete:
            case QuestCommand.Fail:
            case QuestCommand.Activate:
            {
                ActivateQuestByIDName();
                break; 
            }
        }
    }

    private void ActivateQuestByIDName()
    {
        var quest = GetQuestByIDName(_questContext.IDName);
            quest?.Initialize(this);
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

    public override void Clear()
    {
        ProjectBus.Instance.OnQuestContextSignal -= ProcessSignal;
    }
}
