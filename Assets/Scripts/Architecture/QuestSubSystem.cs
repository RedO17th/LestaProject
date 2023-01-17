using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestSubSystem : BaseSubSystem
{
    [Range(1, 21)]
    [SerializeField] private int _questID = 0;
    [SerializeField] private List<QuestContainer> _questÑontainers;

    private QuestContainer _currentQuestContainer = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeQuests();
    }

    private void InitializeQuests()
    {
        foreach (var container in _questÑontainers)
            container.Quest.Initialize(this);
    }

    public override void Prepare()
    {
        SetFirstQuestContainerByID();
    }
    private void SetFirstQuestContainerByID()
    {
        _currentQuestContainer = _questÑontainers[--_questID];
    }

    #region Cycle of switching quests
    public override void StartSystem()
    {
        LaunchQuest();
    }

    private void LaunchQuest()
    {
        if (_currentQuestContainer != null)
        {
            _currentQuestContainer.AddLinksToQuest();
            _currentQuestContainer.ActivateEncouners();

            var quest = _currentQuestContainer.Quest;

            quest.OnCompleted += SwitchToNextQuest;
            quest.Prepare();
            quest.Launch();
        }
        else
        {
            //[ForMe] Êâåñòû çàêîí÷èëèñü, ğåøèòü, ÷òî äåëàòü äàëüøå...
            Debug.Log($"QuestSubSystem.LaunchQuest: quests are over");
        }
    }

    private void SwitchToNextQuest()
    {
        _currentQuestContainer.DeactivateEncouners();

        _currentQuestContainer.Quest.SetCompletedState();
        _currentQuestContainer.Quest.Complete();

        _currentQuestContainer = null;

        DefineNextQuest();
        LaunchQuest();
    }
    private void DefineNextQuest()
    {
        foreach (var container in _questÑontainers)
        {
            if (container.Quest.IsCompleted == false)
            {
                _currentQuestContainer = container;
                break;
            }
        }
    }

    #endregion

    public override void Clear()
    {
        base.Clear();
    }
}

[System.Serializable]
public class QuestContainer
{
    [SerializeField] private BaseQuest _quest;
    [SerializeField] private List<BaseEncounter> _encounters;

    [SerializeField] private List<BaseQuestEntity> _questEntity;

    public BaseQuest Quest => _quest;

    public void AddLinksToQuest()
    {
        foreach (var encounter in _encounters)
            _quest.AddLink(encounter.QuestLink);
    }
    public void ActivateEncouners()
    {
        foreach (var encounter in _encounters)
            encounter.Activate();
    }
    public void DeactivateEncouners()
    {
        foreach (var encounter in _encounters)
            encounter.Deactivate();
    }
}
