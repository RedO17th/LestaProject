using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestSubSystem : BaseSubSystem
{
    [SerializeField] private List<QuestAndEncounters> _questContainer;

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
        var container = GetContainerByQuestID(_questContext.IDName);

        if (container != null)
        {
            var quest = CreateQuest(container);

                quest.AddEncounters(container.GetEncouners());

                quest.Initialize(this);
                quest.Prepare();
                quest.Activate();
        }
    }

    private QuestAndEncounters GetContainerByQuestID(string name)
    {
        QuestAndEncounters result = null;

        foreach (var container in _questContainer)
        {
            if (container.QuestID == name)
            {
                result = container;
                break;
            }
        }

        return result;
    }

    private BaseQuest CreateQuest(QuestAndEncounters container)
    {
        return Instantiate(container.QuestPrefab, transform);
    }



    #endregion

    public override void Clear()
    {
        ProjectBus.Instance.OnQuestContextSignal -= ProcessSignal;
    }
}

[System.Serializable]
public class QuestAndEncounters
{
    [SerializeField] private BaseQuest _questPrefab;
    [SerializeField] private List<BaseEncounter> _encounters;

    public string QuestID => _questPrefab.IDName;
    public BaseQuest QuestPrefab => _questPrefab;

    public List<ITaskEncounter> GetEncouners()
    {
        List<ITaskEncounter> result = new List<ITaskEncounter>();

        foreach (var encounter in _encounters)
        {
            if (encounter is IEncounter e)
                result.Add((ITaskEncounter)e);
        }

        return result;
    }
}
