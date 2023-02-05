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

    //[TODO] ������� ���������� � ������������ � ���������
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

                quest.AddNpcEncounters(container.GetEncounters());
                quest.AddVolumeEncounters(container.GetVolumeEncounters());
                quest.AddInvokerEncounters(container.GetInvokerEncounters());

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

//TODO: Transfer to...
[System.Serializable]
public class QuestAndEncounters
{
    [SerializeField] private BaseQuest _questPrefab;
    [SerializeField] private List<BaseEncounter> _npcEncounters;
    [SerializeField] private List<BaseVolumeEncounter> _volumeEncounters;
    [SerializeField] private List<BaseContextInvoker> _invokerEncounters;

    public string QuestID => _questPrefab.IDName;
    public BaseQuest QuestPrefab => _questPrefab;

    public List<IEncounter> GetEncounters()
    {
        List<IEncounter> result = new List<IEncounter>();

        foreach (var encounter in _npcEncounters)
            result.Add(encounter);

        return result;
    }

    public List<IEncounter> GetVolumeEncounters()
    {
        List<IEncounter> result = new List<IEncounter>();

        foreach (var encounter in _volumeEncounters)
            result.Add(encounter);

        return result;
    }

    public List<IEncounter> GetInvokerEncounters()
    {
        List<IEncounter> result = new List<IEncounter>();

        foreach (var encounter in _invokerEncounters)
            result.Add(encounter);

        return result;
    }
}
