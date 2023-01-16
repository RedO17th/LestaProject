using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSubSystem : BaseSubSystem
{
    [Range(1, 21)]
    [SerializeField] private int _questID = 0;
    [SerializeField] private List<BaseQuest> _quests;

    private BaseQuest _currentQuest = null;

    public override void Initialize(ProjectSystem system)
    {
        base.Initialize(system);

        InitializeQuests();
    }

    private void InitializeQuests()
    {
        foreach (var q in _quests)
            q.Initialize(this);
    }

    public override void Prepare()
    {
        SetFirstQuestByID();
    }
    private void SetFirstQuestByID()
    {
        _currentQuest = _quests[--_questID];
    }

    #region Cycle of switching quests
    public override void StartSystem()
    {
        LaunchQuest();
    }

    private void LaunchQuest()
    {
        if (_currentQuest)
        {
            _currentQuest.OnCompleted += SwitchToNextQuest;
            _currentQuest.Prepare();
            _currentQuest.Launch();
        }
        else
        {
            //[ForMe]  весты закончились, решить, что делать дальше...
            Debug.Log($"QuestSubSystem.LaunchQuest: quests are over");
        }
    }

    private void SwitchToNextQuest()
    {
        _currentQuest?.SetCompletedState();
        _currentQuest?.Complete();

        _currentQuest = null;

        DefineNextQuest();
        LaunchQuest();
    }
    private void DefineNextQuest()
    {
        foreach (var quest in _quests)
        {
            if(quest.IsCompleted == false)
            {
                _currentQuest = quest;
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
